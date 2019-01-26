using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterController characterLeft;
    public CharacterController characterRight;

    public DialogBox dialogBoxLeft;
    public DialogBox dialogBoxRight;

    public LevelController level1;
    public LevelController level2;
    public LevelController level3;
    
    // Start is called before the first frame update
    void Start()
    {
        characterLeft.SetGameManager(this);
        characterRight.SetGameManager(this);
        LoadLevel(level1);
    }

    private void LoadLevel(LevelController level)
    {
        characterLeft.transform.position = level.initialCharacterLeftPosition;
        characterRight.transform.position = level.initialCharacterRightPosition;
    }

    public void PerformAction(CharacterController character)
    {
        Cell cell = GridManager.GetCell(character.FacingPosition());
        DialogBox currentDialogBox;
        
        if (character == characterLeft) currentDialogBox = dialogBoxLeft;
        else currentDialogBox = dialogBoxRight;

        if (cell.GetItem() != null && !string.IsNullOrEmpty(cell.GetItem().message))
        {
            currentDialogBox.ShowMessage(cell.GetItem().message);
        }
    }

    public bool CanMoveTo(Vector2 position)
    {
        return GridManager.CanMoveTo(position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
