public class Level2 : LevelController {
	public Item bitcoin;
	public Item bitcoin2;
	public Item door;


	protected override void OnStart() {
		bitcoin.gameObject.SetActive(true);
		bitcoin2.gameObject.SetActive(true);
		GridManager.InsertItemIn(bitcoin.itemPosition.x, bitcoin.itemPosition.y, bitcoin);
		GridManager.InsertItemIn(bitcoin2.itemPosition.x, bitcoin2.itemPosition.y, bitcoin2);
		GridManager.InsertItemIn(door.itemPosition.x, door.itemPosition.y, door);
	}

	public override void OnTriggerEvent(string item) {
		switch (item) {
			case "bitcoin":
				bitcoin2.isPickable = true;
				GridManager.InsertItemIn(bitcoin2.itemPosition.x, bitcoin2.itemPosition.y, bitcoin2);
				break;
			case "bitcoin2":
				door.isDoor = true;
				break;
		}
	}
	
	
	void Update(){
		
	}
	
	
}