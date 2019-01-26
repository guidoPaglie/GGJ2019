using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public string levelName;

    public List<Item> levelItems = new List<Item>();
    
    private void Start() {
        var textAsset = Resources.Load<TextAsset>(levelName);
        var cellpositionsList = JsonConvert.DeserializeObject<List<CellPosition>>(textAsset.text);
        GridManager.UpdateGridFrom(cellpositionsList);
    }
    
}
