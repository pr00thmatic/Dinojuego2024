using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.InputSystem.InputAction;

public class CarControl : MonoBehaviour {
  private Controls _controls;
  public Controls Controls { get { if (_controls == null) _controls = new(); return _controls; } }
  public NavMeshAgent brain;

  void Start () {
    Controls.Car.SetDestination.performed += HandleSetDestinationPerformed;
  }

  void OnEnable () => Controls.Enable();
  void OnDisable () => Controls.Disable();

  public void HandleSetDestinationPerformed (CallbackContext context) {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Controls.Car.DestinationPosition.ReadValue<Vector2>());
    if (Physics.Raycast(ray, out hit) && hit.collider.GetComponent<Floor>()){
     brain.SetDestination(hit.point);
    }
  }
}
