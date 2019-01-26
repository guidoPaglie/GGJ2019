using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class CellPosition
{
    public readonly float dpX;
    public readonly float dpY;

    public CellPosition(float x, float y)
    {
        dpX = x;
        dpY = y;
    }
}

public class GridManager : MonoBehaviour
{
    private const int width = 30;
    private const int height = 15;

    public GameObject testPrefab;
    public string levelName;

    private Cell[,] grid = new Cell[width, height];
    private static List<CellPosition> cellPositions;

    private bool isDebug = true;

    private void Start()
    {
        if (isDebug)
        {
            Resources.Load(levelName + ".json");
            //JsonConvert.DeserializeObject()
            
            //cellPositions = 
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = new Cell();

                Instantiate(testPrefab, new Vector3(x, y), Quaternion.identity);
            }
        }
    }

    public static void AddCell(float positionX, float positionY)
    {
        cellPositions.Add(new CellPosition(positionX, positionY));
    }

    public static void RemoveCell(float positionX, float positionY)
    {
        var c = cellPositions.First(cell => cell.dpX == positionX && cell.dpY == positionY);
        cellPositions.Remove(c);
    }

    public void OnGUI()
    {
        if (GUILayout.Button("save " + levelName))
        {
            var jsonCellPositions = JsonConvert.SerializeObject(cellPositions);
            Debug.Log(jsonCellPositions);

            File.WriteAllText("Assets/Resources/" + levelName + ".json", jsonCellPositions);
        }
    }
}