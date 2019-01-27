using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
	public const int width = 30;
	public const int height = 15;

	private static Cell[,] grid = new Cell[width, height];

	private static bool isDebug;

	private void Awake() {
		ResetGrid();
	}

	public static void ResetGrid() {
		for (var x = 0; x < width; x++) {
			for (var y = 0; y < height; y++) {
				grid[x, y] = new Cell(x, y);
			}
		}
	}

	public static void InsertItemIn(int x, int y, Item item) {
		grid[x, y].SetItem(item);
		item.gameObject.SetActive(true);
	}
	
	public static void InsertItemIn(Item item) {
		InsertItemIn(item.itemPosition.x, item.itemPosition.y, item);
	}

	public static void UpdateGridFrom(List<CellPosition> cellPositions) {
		foreach (var cellPosition in cellPositions) {
			grid[(int) cellPosition.dpX, (int) cellPosition.dpY].DisableWalk();
		}
	}

	public static bool CanMoveTo(Vector2 nextMovement) {
		try {
			return grid[(int) nextMovement.x, (int) nextMovement.y].IsWalkable();
		}
		catch (Exception e) {
			return false;
		}
	}

	public static Cell GetCell(Vector2 position)
	{
		try {
			return grid[(int) position.x, (int) position.y];
		}
		catch (Exception e) {
			return new Cell(-1,-1);
		}
	}

	public static void RemoveItemIn(int itemPositionX, int itemPositionY, Item potLeft) {
		var cell = GetCell(new Vector2(itemPositionX, itemPositionY));
		cell.SetItem(null);
	}
}