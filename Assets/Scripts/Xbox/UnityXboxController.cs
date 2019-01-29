using UnityEngine;
using XboxCtrlrInput;

public class UnityXboxController : MonoBehaviour {
	public XboxController controller;
	public float directionInputDelay = 0.1f;
	private bool _directionInputBlocked;
	private float _timer;

	void FixedUpdate() {
		if (InteractButtonHold()) {
			OnAHold();
		}
		
		if (InteractButtonPressed()) {
			OnAPressed();
		}
				
		if (InteractButtonUp()) {
			OnAUp();
		}
		
		if (!_directionInputBlocked) {
			if (LeftButtonPressed()) {
				OnLeftStickLeft();
				_directionInputBlocked = true;
			}
			else if (RightButtonPressed()) {
				OnLeftStickRight();
				_directionInputBlocked = true;
			}
			else if (UpButtonPressed()) {
				OnLeftStickUp();
				_directionInputBlocked = true;
			}
			else if (DownButtonPressed()) {
				OnLeftStickDown();
				_directionInputBlocked = true;
			}
			
		}
		else {
			if (_timer <= directionInputDelay) {
				_timer += Time.deltaTime;
			}
			else {
				_timer = 0;
				_directionInputBlocked = false;
			}
		}
	}

	protected virtual void OnAUp() {
		
	}

	private bool InteractButtonUp() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.E : KeyCode.M;
		return Input.GetKeyUp(keyboardKey) || XCI.GetButtonUp(XboxButton.A, controller);
	}

	protected virtual void OnAHold() {
		
	}

	private bool InteractButtonHold() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.E : KeyCode.M;
		return Input.GetKey(keyboardKey) || XCI.GetButton(XboxButton.A, controller);
	}

	private bool InteractButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.E : KeyCode.M;
		return Input.GetKeyDown(keyboardKey) || XCI.GetButtonDown(XboxButton.A, controller);
	}

	protected virtual bool LeftButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.A : KeyCode.LeftArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickX, controller) <= -1 || XCI.GetButton(XboxButton.DPadLeft, controller);
	}

	protected virtual bool RightButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.D : KeyCode.RightArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickX, controller) >= 1 || XCI.GetButton(XboxButton.DPadRight, controller);
	}

	protected virtual bool UpButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.W : KeyCode.UpArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickY, controller) >= 1 || XCI.GetButton(XboxButton.DPadUp, controller);
	}

	protected virtual bool DownButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.S : KeyCode.DownArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickY, controller) <= -1 || XCI.GetButton(XboxButton.DPadDown, controller);
	}

	protected virtual void OnLeftStickDown() {
	}

	protected virtual void OnLeftStickUp() {
	}

	protected virtual void OnLeftStickRight() {
	}

	protected virtual void OnLeftStickLeft() {
	}

	protected virtual void OnAPressed() {
	}
}