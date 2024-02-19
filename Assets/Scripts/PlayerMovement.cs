using System;
using UnityEngine;
using System.Collections;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField, Range(0, 100)] float movementSpeed = 5f;
  [SerializeField] CinemachineVirtualCamera virtualCamera;

  void Update()
  {
    float xAxis = Input.GetAxis("Horizontal");
    Debug.Log($"xAxis: {xAxis}");
    float zAxis = Input.GetAxis("Vertical");
    Debug.Log($"zAxis: {zAxis}");

    Vector3 movement = new Vector3(xAxis, 0, zAxis);
    transform.Translate(movementSpeed * Time.deltaTime * movement);

    transform.eulerAngles = new Vector3(0, virtualCamera.transform.eulerAngles.y, 0);
  }
}
