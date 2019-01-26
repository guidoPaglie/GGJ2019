using System;
using UnityEngine;

public class CharacterController : UnityXboxController {

	public DialogBox dialogBox;
	
	[Range(1, 32)] public int cellSize;
	public SpriteRenderer CharacterSpriteRenderer;
	public Sprite CharacterUpSprite;
	public Sprite CharacterDownSprite;
	public Sprite CharacterLeftSprite;
	public Sprite CharacterRightSprite;
	private Direction _currentDirection = Direction.Up;

	private bool _isJumping;

	void Awake() {
		UpdateSprite(_currentDirection);
	}

	protected override void OnAPressed() {
		Debug.Log("A Pressed");
	}

	protected override void OnBPressed() {
		Debug.Log("B Pressed");
	}

	protected override void OnYPressed() {
		Debug.Log("Y Pressed");
	}

	protected override void OnXPressed() {
		Debug.Log("X Pressed");
	}

	protected override void OnLeftStickLeft() {
		Debug.Log("Left Pressed");
		MoveCharacter(Direction.Left);
	}

	protected override void OnLeftStickRight() {
		Debug.Log("Right Pressed");
		MoveCharacter(Direction.Right);
	}

	protected override void OnLeftStickUp() {
		Debug.Log("Up Pressed");
		MoveCharacter(Direction.Up);
	}

	protected override void OnLeftStickDown() {
		Debug.Log("Down Pressed");
		dialogBox.ShowMessage("La concha de tu madre all boys!!!");
		MoveCharacter(Direction.Down);
	}

	void MoveCharacter(Direction direction) {
		switch (direction) {
			case Direction.Up:
				Move(Direction.Up);
				break;
			case Direction.Down:
				Move(Direction.Down);
				break;
			case Direction.Left:
				Move(Direction.Left);
				break;
			case Direction.Right:
				Move(Direction.Right);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}

		UpdateSprite(direction);
	}

	void UpdateSprite(Direction direction) {
		switch (direction) {
			case Direction.Up:
				CharacterSpriteRenderer.sprite = CharacterUpSprite;
				break;
			case Direction.Down:
				CharacterSpriteRenderer.sprite = CharacterDownSprite;
				break;
			case Direction.Left:
				CharacterSpriteRenderer.sprite = CharacterLeftSprite;
				break;
			case Direction.Right:
				CharacterSpriteRenderer.sprite = CharacterRightSprite;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	void Move(Direction direction) {
		_currentDirection = direction;
		int x;
		int y;
		var transform1 = transform;
		var position = transform1.position;

		if (GridManager.CanMoveTo(NextMovement(direction))) {
			position = NextMovement(direction);
			transform1.position = position;
		}		
	}

	Vector2 NextMovement(Direction direction) {
		switch (direction) {
			case Direction.Up:
				return new Vector2(transform.position.x, transform.position.y + 1);
			case Direction.Down:
				return new Vector2(transform.position.x, transform.position.y - 1);
			case Direction.Left:
				return new Vector2(transform.position.x - 1, transform.position.y);
			case Direction.Right:
				return new Vector2(transform.position.x + 1, transform.position.y);
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	private enum Direction {
		Up,
		Down,
		Left,
		Right
	}
}