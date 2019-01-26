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

		OnLeftXAxisMove(XCI.GetAxis(XboxAxis.LeftStickX, controller));
		OnLeftYAxisMove(XCI.GetAxis(XboxAxis.LeftStickY, controller));

		OnRightXAxisMove(XCI.GetAxis(XboxAxis.RightStickX, controller));
		OnRightYAxisMove(XCI.GetAxis(XboxAxis.RightStickY, controller));

		if (!_directionInputBlocked)
		{
			if (Input.GetKey(KeyCode.LeftArrow) || XCI.GetAxis(XboxAxis.LeftStickX, controller) <= -1) {
				OnLeftStickLeft();
				_directionInputBlocked = true;
			}
			else if (Input.GetKey(KeyCode.RightArrow) || XCI.GetAxis(XboxAxis.LeftStickX, controller) >= 1) {
				OnLeftStickRight();
				_directionInputBlocked = true;
			}
			else if (Input.GetKey(KeyCode.UpArrow) || XCI.GetAxis(XboxAxis.LeftStickY, controller) >= 1) {
				OnLeftStickUp();
				_directionInputBlocked = true;
			}
			else if (Input.GetKey(KeyCode.DownArrow) || XCI.GetAxis(XboxAxis.LeftStickY, controller) <= -1) {
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

	protected virtual void OnLeftStickDown() {
		
	}

	protected virtual void OnLeftStickUp() {
		
	}

	protected virtual void OnLeftStickRight() {
	}

	protected virtual void OnLeftStickLeft() {
	}

	protected virtual void OnRightXAxisMove(float xAxis) {
	}

	protected virtual void OnRightYAxisMove(float yAxis) {
	}

	protected virtual void OnLeftXAxisMove(float xAxis) {
	}

	protected virtual void OnLeftYAxisMove(float yAxis) {
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