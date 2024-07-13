using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControls : MonoBehaviour {
  [Header("Initialization")]
  public Transform pitch;
  public Transform rotation;

  [Header("Information")]
  public Controls controls;
  public Vector2 input;
  public Vector2 currentRotation;

  [Header("Configuration")]
  public Vector2 speed = new(360, 90);
  public Vector2 clampPitch = new(0, 60);

  void Start () {
    controls = new Controls();
    controls.Enable();
    currentRotation = new(pitch.localRotation.eulerAngles.x, rotation.localRotation.eulerAngles.y);
  }

  void Update () {
    input = controls.Camera.Rotation.ReadValue<Vector2>() * Time.deltaTime;
    input.y *= -1;

    if (controls.Camera.Holding.IsPressed()) {
      currentRotation += Vector2.Scale(input, speed);
      currentRotation.y = Mathf.Clamp(currentRotation.y, clampPitch.x, clampPitch.y);

      pitch.localRotation = Quaternion.Euler(currentRotation.y, 0, 0);
      rotation.localRotation = Quaternion.Euler(0, currentRotation.x, 0);
    }
  }
}
