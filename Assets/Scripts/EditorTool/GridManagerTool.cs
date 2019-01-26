using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GridManagerTool : MonoBehaviour {
	public string levelName;
	public GameObject TestPrefab;
	private static ClickableCells[,] gridReference = new ClickableCells[GridManager.width, GridManager.height];
	private static List<CellPosition> cellPositions = new List<CellPosition>();


	void Start() {
		for (var x = 0; x < GridManager.width; x++) {
			for (var y = 0; y < GridManager.height; y++) {
					gridReference[x, y] = Instantiate(TestPrefab, new Vector3(x, y), Quaternion.identity)
						.GetComponent<ClickableCells>();
					gridReference[x, y].transform.SetParent(transform);
			}
		}
	}
	
	public void OnGUI() {
		if (GUILayout.Button("Save " + levelName)) {
			var jsonCellPositions = JsonConvert.SerializeObject(cellPositions, Formatting.Indented);
			File.WriteAllText("Assets/Resources/" + levelName + ".json", jsonCellPositions, Encoding.UTF8);

#if UNITY_EDITOR
			AssetDatabase.Refresh();
#endif
		}

		if (GUILayout.Button("Load " + levelName)) {
			var textAsset = Resources.Load<TextAsset>(levelName);
			var cellpositionsList = JsonConvert.DeserializeObject<List<CellPosition>>(textAsset.text);
			ResetAllTiles();
			UpdateTileReferences(cellpositionsList);
			GridManager.UpdateGridFrom(cellpositionsList);			
					
		}
	}

	private void ResetAllTiles() {
		for (var x = 0; x < GridManager.width; x++) {
			for (var y = 0; y < GridManager.height; y++) {
				gridReference[x, y].Reset();
			}
		}
		cellPositions = new List<CellPosition>();
	}

	void UpdateTileReferences(List<CellPosition> cellPositions) {
		foreach (var cellPosition in cellPositions) {
			gridReference[(int) cellPosition.dpX, (int) cellPosition.dpY].Click();	
		}		
	}
	
	public static void AddCell(float positionX, float positionY) {
		cellPositions.Add(new CellPosition(positionX, positionY));
	}

	public static void RemoveCell(float positionX, float positionY) {
		if (!cellPositions.Any()) return;
		var c = cellPositions.First(cell => cell.dpX == positionX && cell.dpY == positionY);
		cellPositions.Remove(c);
	}
}