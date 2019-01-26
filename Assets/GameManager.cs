using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
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
    private LevelController _currentLevel;
    
    private Dictionary<string, Dictionary<string, string>> dialogs = new Dictionary<string, Dictionary<string, string>>();
    // Start is called before the first frame update
    void Start()
    {
        var textAsset = Resources.Load<TextAsset>("dialogs");
        dialogs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(textAsset.text);
        
        characterLeft.SetGameManager(this);
        characterRight.SetGameManager(this);
        LoadLevel(level1);
    }


    private void LoadLevel(LevelController level)
    {
        characterLeft.transform.position = level.initialCharacterLeftPosition;
        characterRight.transform.position = level.initialCharacterRightPosition;
        
        if(_currentLevel != null)
            _currentLevel.gameObject.SetActive(false);
        
        _currentLevel = level;
        _currentLevel.gameObject.SetActive(true);
        
        var cellpositionsList = _currentLevel.GetCellPositions();
        GridManager.ResetGrid();
        GridManager.UpdateGridFrom(cellpositionsList);
        
        _currentLevel.Init();
    }

    public void PerformAction(CharacterController character)
    {
        Cell cell = GridManager.GetCell(character.FacingPosition());
        Item item = cell.GetItem();

        if (item == null) return;

        if (item.isDoor) {
            LoadLevel(level2);
            return;
        }
        
        PerformDialog(item, character);
        PerformPick(cell, character);
    }

    private void PerformDialog(Item item, CharacterController character)
    {
        DialogBox currentDialogBox;
        
        if (character == characterLeft) currentDialogBox = dialogBoxLeft;
        else currentDialogBox = dialogBoxRight;

        if (!string.IsNullOrEmpty(item.message))
        {
            currentDialogBox.ShowMessage(dialogs[_currentLevel.levelName][item.message]);
        }
    }

    private void PerformPick(Cell cell, CharacterController character)
    {
        if (cell.GetItem().isPickable)
        {
            var id = cell.GetItem().id;
            character.pickedItemId = id;
            cell.SetItem(null);
            _currentLevel.OnTriggerEvent(id);
        } 
    }

    public bool CanMoveTo(Vector2 position)
    {
        return GridManager.CanMoveTo(position);
    }
}
