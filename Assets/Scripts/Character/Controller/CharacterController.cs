using System;
using UnityEngine;

public class CharacterController : UnityXboxController {
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
		MoveCharacter(Direction.Left);
	}

	protected override void OnLeftStickRight() {
		MoveCharacter(Direction.Right);
	}

	protected override void OnLeftStickUp() {
		MoveCharacter(Direction.Up);
	}

	protected override void OnLeftStickDown() {
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
		
		switch (direction) {
			case Direction.Up:
				x = 0;
				y = 1;
				break;
			case Direction.Down:
				x = 0;
				y = -1;
				break;
			case Direction.Left:
				x = -1;
				y = 0;
				break;
			case Direction.Right:
				x = 1;
				y = 0;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
		position = new Vector2(position.x + cellSize * x, position.y + cellSize * y);
		transform1.position = position;
	}

	protected override void OnLeftYAxisMove(float yAxis) {
	}

	protected override void OnRightXAxisMove(float xAxis) {
	}

	protected override void OnRightYAxisMove(float yAxis) {
	}

	private enum Direction {
		Up,
		Down,
		Left,
		Right
	}
}