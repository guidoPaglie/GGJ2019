﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Cell[,] grid = new Cell[60,30];
    public GameObject testPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 60; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                grid[x,y] = new Cell();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}