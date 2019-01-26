using UnityEngine.Serialization;

public class Level1 : LevelController {
	public Item cartridgeTrigger1;
	public Item cartridgeTrigger2;
	public Item cartridgeTrigger3;
	public Item cartridgeLeft;
	public Item cartridgeRight;
	public Item doorLeft;
	public Item doorRight;
	public Item pot;
	public Item potCollider;
	public Item potLeft;
	public Item brokenPotLeft;
	public Item ballLeft;
	[FormerlySerializedAs("brokenBallRight")] public Item ballRight;

	protected override void OnStart() {
		cartridgeLeft.gameObject.SetActive(false);
		cartridgeRight.gameObject.SetActive(false);
		brokenPotLeft.gameObject.SetActive(false);
		ballLeft.gameObject.SetActive(false);
		GridManager.InsertItemIn(pot.itemPosition.x, pot.itemPosition.y, pot);
		GridManager.InsertItemIn(potCollider.itemPosition.x, potCollider.itemPosition.y, potCollider);
		GridManager.InsertItemIn(cartridgeTrigger1.itemPosition.x, cartridgeTrigger1.itemPosition.y, cartridgeTrigger1);
		GridManager.InsertItemIn(cartridgeTrigger2.itemPosition.x, cartridgeTrigger2.itemPosition.y, cartridgeTrigger2);
		GridManager.InsertItemIn(cartridgeTrigger3.itemPosition.x, cartridgeTrigger3.itemPosition.y, cartridgeTrigger3);
		GridManager.InsertItemIn(doorLeft.itemPosition.x, doorLeft.itemPosition.y, doorLeft);
		GridManager.InsertItemIn(doorRight.itemPosition.x, doorRight.itemPosition.y, doorRight);
		GridManager.InsertItemIn(potLeft.itemPosition.x, potLeft.itemPosition.y, potLeft);		
		GridManager.InsertItemIn(ballRight.itemPosition.x, ballRight.itemPosition.y, ballRight);		
	}

	public override void OnTriggerEvent(string itemId) {
		switch (itemId) {
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
				break;
			case "ball_right":
				ballLeft.gameObject.SetActive(true);
				GridManager.InsertItemIn(ballLeft.itemPosition.x, ballLeft.itemPosition.y, ballLeft);
				break;
			case "ball_left":
				_gameManager.AnimateItemTo(ballLeft, Direction.Up, 3, () => {
					GridManager.RemoveItemIn(potLeft.itemPosition.x, potLeft.itemPosition.y, potLeft);
					potLeft.DestroyItem();
					brokenPotLeft.gameObject.SetActive(true);
					GridManager.InsertItemIn(brokenPotLeft.itemPosition.x, brokenPotLeft.itemPosition.y, brokenPotLeft);
				});
				break;
		}
	}
}