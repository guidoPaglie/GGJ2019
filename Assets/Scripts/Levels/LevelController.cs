using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public string levelName;
    public Vector2 initialCharacterLeftPosition;
    public Vector2 initialCharacterRightPosition;
    protected GameManager _gameManager;
    
    public List<Item> dialogs;
    
    public void Init() {
        OnStart();
    }
    
    protected virtual void OnStart() {
        dialogs.ForEach(GridManager.InsertItemIn);
    }

    public virtual void OnTriggerEvent(string itemId) {
        
    }

    public List<CellPosition> GetCellPositions() {
        var textAsset = Resources.Load<TextAsset>(levelName);
        return JsonConvert.DeserializeObject<List<CellPosition>>(textAsset.text);
    }

    public void SetGameManager(GameManager gameManager) {
        _gameManager = gameManager;
    }
}
