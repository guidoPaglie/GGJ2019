using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public string levelName;
    public Vector2 initialCharacterLeftPosition;
    public Vector2 initialCharacterRightPosition;
    
    public void Init() {
        OnStart();
    }
    
    protected virtual void OnStart() {
    }

    public virtual void OnTriggerEvent(string itemId) {
        
    }

    public List<CellPosition> GetCellPositions() {
        var textAsset = Resources.Load<TextAsset>(levelName);
        return JsonConvert.DeserializeObject<List<CellPosition>>(textAsset.text);
    }
}
