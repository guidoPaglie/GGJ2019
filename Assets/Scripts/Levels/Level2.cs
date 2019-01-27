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
	public Item door_left;
	public Item door_right;

	private bool hasJoystick;
	private bool hasPhonebook;

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
		GridManager.InsertItemIn(door_left);
		GridManager.InsertItemIn(door_right);
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
				
				_gameManager.AnimateItemTo(rat, Direction.Up, 1, () =>
				{
					GridManager.InsertItemIn(joystick);

					_gameManager.AnimateItemTo(rat, Direction.Right, 3, () =>
					{
						_gameManager.AnimateItemTo(rat, Direction.Up, 1, () =>
						{
							_gameManager.AnimateItemTo(rat, Direction.Left, 6, () =>
							{
								_gameManager.AnimateItemTo(rat, Direction.Up, 1, () =>
								{
									_gameManager.AnimateItemTo(rat, Direction.Right, 4, () =>
									{
										GridManager.RemoveItemIn(rat.itemPosition.x, rat.itemPosition.y, rat);
										GridManager.RemoveItemIn(cupboard_right_1.itemPosition.x,
											cupboard_right_1.itemPosition.y,
											cupboard_right_1);
										GridManager.RemoveItemIn(cupboard_right_2.itemPosition.x,
											cupboard_right_2.itemPosition.y,
											cupboard_right_2);
										rat.DestroyItem();
										cupboard_right_1.DestroyItem();
										cupboard_right_2.DestroyItem();

										GridManager.InsertItemIn(cupboard_right_open_1);
										GridManager.InsertItemIn(cupboard_right_open_2);
										
										GridManager.InsertItemIn(phonebook);

										cupboard_right_3.message = "cupboard_open_right";
										cupboard_right_4.message = "cupboard_open_right";
									});
								});
							});
						});
					});
				});
				break;
			case "joystick_right":
				hasJoystick = true;
				if (hasPhonebook) ringPhoneEvent();
				break;
			case "phonebook_right":
				hasPhonebook = true;
				if (hasJoystick) ringPhoneEvent();
				break;
			case "phone_ring_left":
				phone_left.id = "phone_rang_left";
				phone_left.message = "phone_ring_right";

				door_right.message = null;
				
				phone_left.StopAnimation();
				break;
			case "door_right":
				if (_gameManager.IsCharacterHoldingXYB()) 
					_gameManager.LoadLevel3();
				break;
		}
	}

	private void ringPhoneEvent()
	{
		phonebook.id = "phonebook_right_read";

		phone_left.id = "phone_ring_left";
		phone_left.message = "phone_ring_left";
				
		phone_left.Animate();
				
		phone_right.message = "phone_ring_right";
	}
	
	
	void Update(){
		
	}
	
	
}