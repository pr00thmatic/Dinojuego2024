using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControls : MonoBehaviour {
  [Header("Initialization")]
  public Transform pitch;
  public Transform rotation;

  [Header("Information")]
  private Controls _controls;
  public Controls Controls { get { if (_controls == null) _controls = new(); return _controls; } }
  public Vector2 input;
  public Vector2 currentRotation;

  [Header("Configuration")]
  public Vector2 speed = new(360, 90);
  public Vector2 clampPitch = new(0, 60);

  void OnEnable () {
    Controls.Enable();
    currentRotation = new(rotation.localRotation.eulerAngles.y, pitch.localRotation.eulerAngles.x);
  }

  void OnDisable () {
    Controls.Disable();
  }

  void Update () {
    input = Controls.Camera.Rotation.ReadValue<Vector2>() * Time.deltaTime;
    input.y *= -1;

    if (Controls.Camera.Holding.IsPressed()) {
      currentRotation += Vector2.Scale(input, speed);
      currentRotation.y = Mathf.Clamp(currentRotation.y, clampPitch.x, clampPitch.y);

      pitch.localRotation = Quaternion.Euler(currentRotation.y, 0, 0);
      rotation.localRotation = Quaternion.Euler(0, currentRotation.x, 0);
    }
  }
}
