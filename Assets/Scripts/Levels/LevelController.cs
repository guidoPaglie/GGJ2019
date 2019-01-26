using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public string levelName;
    public Vector2 initialCharacterLeftPosition;
    public Vector2 initialCharacterRightPosition;

    public List<Item> levelItems = new List<Item>();
    
    private void Start() {
        SetupGrid();
    }

    private void SetupGrid()
    {
        var textAsset = Resources.Load<TextAsset>(levelName);
        var cellpositionsList = JsonConvert.DeserializeObject<List<CellPosition>>(textAsset.text);
        GridManager.ResetGrid();
        GridManager.UpdateGridFrom(cellpositionsList);

        foreach (var item in levelItems) {
            GridManager.InsertItemIn(item.itemPosition.x, item.itemPosition.y, item);
        }
    }
}
