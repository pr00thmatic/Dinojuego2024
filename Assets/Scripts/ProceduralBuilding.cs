using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode, SelectionBase]
public class ProceduralBuilding : MonoBehaviour {
  public Vector2 heightRange = new(1.5f, 3);

  void OnEnable () {
    transform.localScale = new(1, Random.Range(heightRange.x, heightRange.y), 1);
  }
}
