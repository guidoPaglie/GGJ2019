using UnityEngine;

public class GridManager : MonoBehaviour
{
    private const int width = 30;
    private const int height = 15;
    
    private Cell[,] grid = new Cell[width,height];
    public GameObject testPrefab;
    
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x,y] = new Cell();

                Instantiate(testPrefab, new Vector3(x, y,- 1), Quaternion.identity);
            }
        }
    }
}