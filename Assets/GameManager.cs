using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public ItemHighlight ItemHighlight;
	
	public CharacterController characterLeft;
	public CharacterController characterRight;

	public DialogBox dialogBoxLeft;
	public DialogBox dialogBoxRight;

	public LevelController level1;
	public LevelController level2;
	public LevelController level3;
	private LevelController _currentLevel;

	public PickableItemView PickablesLeft;
	public PickableItemView PickablesRight;
	
	private Dictionary<string, Dictionary<string, string>> dialogs =
		new Dictionary<string, Dictionary<string, string>>();

	// Start is called before the first frame update
	void Start() {
		var textAsset = Resources.Load<TextAsset>("dialogs");
		dialogs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(textAsset.text);

		characterLeft.SetGameManager(this);
		characterRight.SetGameManager(this);
		LoadLevel(level1);
	}


	private void LoadLevel(LevelController level) {
		characterLeft.transform.position = level.initialCharacterLeftPosition;
		characterRight.transform.position = level.initialCharacterRightPosition;

		if (_currentLevel != null)
			_currentLevel.gameObject.SetActive(false);

		_currentLevel = level;
		_currentLevel.SetGameManager(this);
		_currentLevel.gameObject.SetActive(true);

		var cellpositionsList = _currentLevel.GetCellPositions();
		GridManager.ResetGrid();
		GridManager.UpdateGridFrom(cellpositionsList);

		_currentLevel.Init();
		
		PickablesLeft.ResetItems();
		PickablesRight.ResetItems();
	}

	public void LoadLevel3()
	{
		LoadLevel(level3);
	}

	public void PerformAction(CharacterController character) {
		Cell cell = GridManager.GetCell(character.FacingPosition());
		Item item = cell.GetItem();

		if (item == null) return;

		if (item.isDoor) {
			LoadLevel(level2);
			return;
		}
		
		PerformDialog(item, character);
		PerformPick(cell, character);
		_currentLevel.OnTriggerEvent(item.id);
	}

	private void PerformDialog(Item item, CharacterController character) {
		DialogBox currentDialogBox;

		if (character == characterLeft) currentDialogBox = dialogBoxLeft;
		else currentDialogBox = dialogBoxRight;

		if (!string.IsNullOrEmpty(item.message)) {
			currentDialogBox.ShowMessage(dialogs[_currentLevel.levelName][item.message]);
		}
	}

	public void PerformPick(Cell cell, CharacterController character) {
		if (cell.GetItem().isPickable) {
			var id = cell.GetItem().id;
			character.pickedItemId = id;
			cell.SetItem(null);
		}
	}

	public bool CanMoveTo(Vector2 position) {
		return GridManager.CanMoveTo(position);
	}

	public void MoveCharacter(CharacterController characterController, Vector2 nextMove) {
		characterController.gameObject.transform.position = nextMove;
		var item = GridManager.GetCell(nextMove).GetItem();
		if (item == null) return;
		if (item.isTrigger) {
			_currentLevel.OnTriggerEvent(item.id);
		}
	}

	public void AnimateItemTo(Item item, Direction direction, int tilesQty, Action onEnd) {
		StartCoroutine(AnimateItem(item, direction, tilesQty, onEnd));
	}

	public bool IsCharacterHoldingXYB() {
		return characterLeft.IsHoldingXYB() || characterRight.IsHoldingXYB();
	}

	public void HighlightItem(string itemResourcesName) {
		ItemHighlight.HighlightItem(itemResourcesName);
	}
	
	private IEnumerator AnimateItem(Item item, Direction direction, int tilesQty, Action onEnd) {
		for (int i = 0; i < tilesQty; i++) {
			var cell = GridManager.GetCell(new Vector2(item.itemPosition.x, item.itemPosition.y));
			cell.SetItem(null);
			
			Cell nextCell = null;
			switch (direction) {
				case Direction.Up:
					nextCell = GridManager.GetCell(new Vector2(item.itemPosition.x, item.itemPosition.y + 1));
					break;
				case Direction.Down:
					nextCell = GridManager.GetCell(new Vector2(item.itemPosition.x, item.itemPosition.y - 1));
					break;
				case Direction.Left:
					nextCell = GridManager.GetCell(new Vector2(item.itemPosition.x - 1, item.itemPosition.y));
					break;
				case Direction.Right:
					nextCell = GridManager.GetCell(new Vector2(item.itemPosition.x + 1, item.itemPosition.y));
					break;
			}

			nextCell.SetItem(item);
			
			yield return new WaitForSeconds(0.033f);
		}

		onEnd();
	}

	public void ItemDepositLeft(string item)
	{
		if (item == "cupboard_full_left" || item == "drawer_left_key" || item == "chest_right_key")
		{
			characterLeft.pickedItemId = "";
			PickablesLeft.ResetItems();
		}
	}
	
	public void ItemDepositRight(string item)
	{
		if (item == "cupboard_full_left" || item == "drawer_left_key" || item == "chest_right_key")
		{
			characterRight.pickedItemId = "";
			PickablesRight.ResetItems();
		}
	}
}