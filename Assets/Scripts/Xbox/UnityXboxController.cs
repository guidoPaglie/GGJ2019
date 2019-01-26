using UnityEngine;
using XboxCtrlrInput;

public class UnityXboxController : MonoBehaviour {
	public XboxController controller;
	public float directionInputDelay = 0.1f;
	private bool _directionInputBlocked;
	private float _timer;

	void FixedUpdate() {
		if (XCI.GetButtonDown(XboxButton.A, controller)) {
			OnAPressed();
		}

		if (XCI.GetButtonDown(XboxButton.B, controller)) {
			OnBPressed();
		}

		if (XCI.GetButtonDown(XboxButton.X, controller)) {
			OnXPressed();
		}

		if (XCI.GetButtonDown(XboxButton.Y, controller)) {
			OnYPressed();
		}

		if (XCI.GetButton(XboxButton.A, controller)) {
			OnAHold();
		}

		if (XCI.GetButton(XboxButton.B, controller)) {
			OnBHold();
		}

		if (XCI.GetButton(XboxButton.X, controller)) {
			OnXHold();
		}

		if (XCI.GetButton(XboxButton.Y, controller)) {
			OnYHold();
		}

		if (!_directionInputBlocked)
		{
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

	protected virtual bool LeftButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.A : KeyCode.LeftArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickX, controller) <= -1;
	}
	
	protected virtual bool RightButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.D : KeyCode.RightArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickX, controller) >= 1;
	}
	
	protected virtual bool UpButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.W : KeyCode.UpArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickY, controller) >= 1;
	}
	
	protected virtual bool DownButtonPressed() {
		KeyCode keyboardKey = controller == XboxController.First ? KeyCode.S : KeyCode.DownArrow;
		return Input.GetKey(keyboardKey) || XCI.GetAxis(XboxAxis.LeftStickY, controller) <= -1;
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

	protected virtual void OnBPressed() {
	}

	protected virtual void OnXPressed() {
	}

	protected virtual void OnYPressed() {
	}

	protected virtual void OnAHold() {
	}

	protected virtual void OnBHold() {
	}

	protected virtual void OnYHold() {
	}

	protected virtual void OnXHold() {
	}
}