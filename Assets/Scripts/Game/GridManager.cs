using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
	public const int width = 30;
	public const int height = 15;

	private static Cell[,] grid = new Cell[width, height];
	private static List<CellPosition> cellPositions;

	private static bool isDebug;

	private void Awake() {
		cellPositions = new List<CellPosition>();

		for (var x = 0; x < width; x++) {
			for (var y = 0; y < height; y++) {
				grid[x, y] = new Cell();
			}
		}
	}

	public static void UpdateGridFrom(List<CellPosition> cellPositions) {
		foreach (var cellPosition in cellPositions) {
			grid[(int) cellPosition.dpX, (int) cellPosition.dpY].DisableWalk();
		}
	}

	public static bool CanMoveTo(Vector2 nextMovement) {
		try {
			return grid[(int) nextMovement.x, (int) nextMovement.y]._walkable;
		}
		catch (Exception e) {
			return false;
		}
	}
}