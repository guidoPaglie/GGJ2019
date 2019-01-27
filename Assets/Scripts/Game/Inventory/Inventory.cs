using System;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class Inventory : MonoBehaviour
    {
        public List<SpriteRenderer> ItemsLevelsSR;
        public CharacterController PlayerControllerRight;

        private string currentItemId = "";
        private int inventoryCount;

        private void Awake()
        {
            ItemsLevelsSR.ForEach(sr => sr.enabled = false);
        }

        private void Update()
        {
            if (!String.IsNullOrEmpty(PlayerControllerRight.pickedItemId) &&
                !currentItemId.Equals(PlayerControllerRight.pickedItemId))
            {
                currentItemId = PlayerControllerRight.pickedItemId;

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