using System.Timers;
using UnityEngine;
using XboxCtrlrInput;

public class UnityXboxController : MonoBehaviour {
	public XboxController controller;
	public float stickDelay = 0.2f;
	private bool _leftStickLeft;
	private bool _leftStickRight;
	private bool _leftStickUp;
	private bool _leftStickDown;
	private bool _tick;
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

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			OnLeftStickLeft();
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			OnLeftStickRight();
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			OnLeftStickUp();
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			OnLeftStickDown();
		}
		
		if (!_leftStickRight) {
			if (XCI.GetAxis(XboxAxis.LeftStickX, controller) >= 1) {
				OnLeftStickRight();
				_leftStickRight = true;
				_tick = true;
			}
		}
		else {
			if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0.5f) {
				_leftStickRight = false;
			}
		}

		if (!_leftStickLeft) {
			if (XCI.GetAxis(XboxAxis.LeftStickX, controller) <= -1) {
				OnLeftStickLeft();
				_leftStickLeft = true;
				_tick = true;
			}
		}
		else {
			if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > -0.5f) {
				_leftStickLeft = false;
			}
		}
		
		if (!_leftStickUp) {
			if (XCI.GetAxis(XboxAxis.LeftStickY, controller) >= 1) {
				OnLeftStickUp();
				_leftStickUp = true;
				_tick = true;
			}
		}
		else {
			if (XCI.GetAxis(XboxAxis.LeftStickY, controller) < 0.5f) {
				_leftStickUp = false;
			}
		}

		
		if (!_leftStickDown) {
			if (XCI.GetAxis(XboxAxis.LeftStickY, controller) <= -1) {
				OnLeftStickDown();
				_leftStickDown = true;
				_tick = true;
			}
		}
		else {
			if (XCI.GetAxis(XboxAxis.LeftStickY, controller) > -0.5f) {
				_leftStickDown = false;
			}
		}

		if (_tick) {
			if (_timer <= stickDelay) {
				_timer += Time.deltaTime;
			}
			else {
				_timer = 0;
				_tick = false;
				_leftStickDown = false;
				_leftStickUp = false;
				_leftStickLeft = false;
				_leftStickRight = false;
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