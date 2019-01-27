using UnityEngine;
using UnityEngine.Serialization;

public class Level1 : LevelController {
	public Animator BlackFade;
	public Item cartridgeTrigger1;
	public Item cartridgeTrigger2;
	public Item cartridgeTrigger3;
	public Item cartridgeLeft;
	public Item cartridgeRight;
	public Item doorLeft;
	public Item doorRight;
	public Item potRight;
	public Item potRightCollider;
	public Item potLeft;
	public Item brokenPotLeft;
	public Item ballLeft;
	public Item memoryTrigger01;
	public Item memoryTrigger02;
	public Item memoryTrigger03;
	public Item memoryTrigger04;
	[FormerlySerializedAs("brokenBallRight")] public Item ballRight;

	protected override void OnStart() {
		_gameManager.characterLeft.enabled = false;
		cartridgeLeft.gameObject.SetActive(false);
		cartridgeRight.gameObject.SetActive(false);
		brokenPotLeft.gameObject.SetActive(false);
		ballLeft.gameObject.SetActive(false);
		GridManager.InsertItemIn(potRight.itemPosition.x, potRight.itemPosition.y, potRight);
		GridManager.InsertItemIn(potRightCollider.itemPosition.x, potRightCollider.itemPosition.y, potRightCollider);
		GridManager.InsertItemIn(cartridgeTrigger1.itemPosition.x, cartridgeTrigger1.itemPosition.y, cartridgeTrigger1);
		GridManager.InsertItemIn(cartridgeTrigger2.itemPosition.x, cartridgeTrigger2.itemPosition.y, cartridgeTrigger2);
		GridManager.InsertItemIn(cartridgeTrigger3.itemPosition.x, cartridgeTrigger3.itemPosition.y, cartridgeTrigger3);
		GridManager.InsertItemIn(doorLeft.itemPosition.x, doorLeft.itemPosition.y, doorLeft);
		GridManager.InsertItemIn(doorRight.itemPosition.x, doorRight.itemPosition.y, doorRight);
		GridManager.InsertItemIn(potLeft.itemPosition.x, potLeft.itemPosition.y, potLeft);		
		GridManager.InsertItemIn(ballRight.itemPosition.x, ballRight.itemPosition.y, ballRight);
		GridManager.InsertItemIn(memoryTrigger01);
		GridManager.InsertItemIn(memoryTrigger02);
		GridManager.InsertItemIn(memoryTrigger03);
		GridManager.InsertItemIn(memoryTrigger04);
	}

	private bool _leftSideEnabled = false;
	public override void OnTriggerEvent(string itemId) {
		if (!_leftSideEnabled) {
			EnablePlayerLeft();			
		}
		
		switch (itemId) {
			case "memory_trigger":
				memoryTrigger01.DestroyItem();
				memoryTrigger02.DestroyItem();
				memoryTrigger03.DestroyItem();
				memoryTrigger04.DestroyItem();
				break;
			case "cartridge_trigger":
				GridManager.InsertItemIn(cartridgeLeft.itemPosition.x, cartridgeLeft.itemPosition.y, cartridgeLeft);
				GridManager.InsertItemIn(cartridgeRight.itemPosition.x, cartridgeRight.itemPosition.y, cartridgeRight);
				cartridgeLeft.gameObject.SetActive(true);
				cartridgeRight.gameObject.SetActive(true);
				cartridgeTrigger1.DestroyItem();
				cartridgeTrigger2.DestroyItem();
				cartridgeTrigger3.DestroyItem();
				break;
			case "cartridge_right":
				ballRight.id = "ball_right";
				ballRight.message = "ball_callback_right";
				_gameManager.HighlightItem("Cartucho");
				break;
			case "ball_right":
				ballLeft.gameObject.SetActive(true);
				GridManager.InsertItemIn(ballLeft.itemPosition.x, ballLeft.itemPosition.y, ballLeft);
				break;
			case "ball_left":
				_gameManager.AnimateItemTo(ballLeft, Direction.Up, 3, () => {
					GridManager.RemoveItemIn(potLeft.itemPosition.x, potLeft.itemPosition.y);
					potLeft.DestroyItem();
					brokenPotLeft.gameObject.SetActive(true);
					potRight.gameObject.SetActive(false);
					doorRight.isDoor = true;
					GridManager.RemoveItemIn(potRight.itemPosition.x, potRight.itemPosition.y);
					GridManager.RemoveItemIn(potRightCollider.itemPosition.x, potRightCollider.itemPosition.y);
					GridManager.InsertItemIn(brokenPotLeft.itemPosition.x, brokenPotLeft.itemPosition.y, brokenPotLeft);
					ballLeft.message = "";
					ballLeft.id = "";
				});
				break;
		}
	}

	void EnablePlayerLeft() {
		_leftSideEnabled = true;
		BlackFade.SetTrigger("Play");
		_gameManager.characterLeft.enabled = true;
	}
}