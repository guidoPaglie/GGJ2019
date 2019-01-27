public class Level2 : LevelController
{
	public Item rat;
	public Item phonebook;
	public Item cookies;
	public Item cupboard_right_1;
	public Item cupboard_right_2;
	public Item cupboard_right_3;
	public Item cupboard_right_4;
	public Item cupboard_right_open_1;
	public Item cupboard_right_open_2;
	public Item cupboard_left;
	public Item cupboard_left_block;
	public Item joystick;
	public Item note;
	public Item phone_right;
	public Item phone_left;
	public Item door;


	protected override void OnStart() {
		GridManager.InsertItemIn(rat);
		GridManager.InsertItemIn(cupboard_left);
		GridManager.InsertItemIn(cupboard_left_block);
		GridManager.InsertItemIn(cupboard_right_1);
		GridManager.InsertItemIn(cupboard_right_2);
		GridManager.InsertItemIn(cupboard_right_3);
		GridManager.InsertItemIn(cupboard_right_4);
		GridManager.InsertItemIn(cookies);
		GridManager.InsertItemIn(note);
		GridManager.InsertItemIn(phone_right);
		GridManager.InsertItemIn(phone_left);
	}

	public override void OnTriggerEvent(string item) {
		switch (item) {
			case "cookies_left":
				cupboard_left.id = "cupboard_full_left";
				cupboard_left_block.id = "cupboard_full_left";

				cupboard_left.message = "cupboard_full_left";
				cupboard_left_block.message = "cupboard_full_left";
				break;
			case "cupboard_full_left":
				cupboard_left.id = "cupboard_left";
				cupboard_left_block.id = "cupboard_left";
				
				_gameManager.AnimateItemTo(rat, Direction.Up, 3, () => {
					
				});
				break;
		}
	}
	
	
	void Update(){
		
	}
	
	
}