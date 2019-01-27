using System;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class Inventory : MonoBehaviour
    {
        public List<SpriteRenderer> ItemsLevelsSR;
        public CharacterController PlayerControllerTwo;

        private string currentItemId = "";
        private int inventoryCount;

        private void Update()
        {
            if (!String.IsNullOrEmpty(PlayerControllerTwo.pickedItemId) &&
                !currentItemId.Equals(PlayerControllerTwo.pickedItemId))
            {
                currentItemId = PlayerControllerTwo.pickedItemId;

                if (!IsItemLevel(currentItemId)) 
                    return;
                
                ItemsLevelsSR[inventoryCount].enabled = true;
                inventoryCount++;

                if (inventoryCount >= ItemsLevelsSR.Count)
                    enabled = false;
            }
        }

        private bool IsItemLevel(string itemId)
        {
            return itemId.Equals("cartridge_right") || 
                   itemId.Equals("joystick_right") || 
                   itemId.Equals("console_right");
        }
    }
}