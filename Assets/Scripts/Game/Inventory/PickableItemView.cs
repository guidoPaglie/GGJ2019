using System;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemView : MonoBehaviour
{
    private const string COOKIES_ID = "cookies";
    private const string KEY_RIGHT_ID = "key_right";
    private const string KEY_LEFT_ID = "key_left";

    public List<Sprite> ItemsSprites;
    public SpriteRenderer ItemSpriteRenderer;
    public CharacterController Character;
    
    private string currentItemId = "";

    private void Update()
    {
        if (!String.IsNullOrEmpty(Character.pickedItemId) &&
            !currentItemId.Equals(Character.pickedItemId))
        {
            currentItemId = Character.pickedItemId;

            if (!IsPickableItem(currentItemId))
                return;

            ItemSpriteRenderer.sprite = GetSpriteById();
        }
    }

    private Sprite GetSpriteById()
    {
        switch (currentItemId)
        {
            case COOKIES_ID:
                return ItemsSprites[0];
            case KEY_LEFT_ID:
            case KEY_RIGHT_ID:
                return ItemsSprites[1];
        }

        return ItemsSprites[0];
    }

    private bool IsPickableItem(string itemId)
    {
        return itemId.Equals(COOKIES_ID) ||
               itemId.Equals(KEY_LEFT_ID) ||
               itemId.Equals(KEY_RIGHT_ID);
    }
}