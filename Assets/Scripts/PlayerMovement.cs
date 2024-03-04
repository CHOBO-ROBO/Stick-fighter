using System;
using UnityEngine;
using System.Collections;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField, Range(0, 100)] float movementSpeed = 5f;
  [SerializeField] CinemachineVirtualCamera virtualCamera;

  Animator animator;

  float deadZone = 0.1f;

  void Start()
  {
    Transform model = transform.Find("kid");
    animator = model.GetComponent<Animator>();
  }

  void Update()
  {
    float xAxis = Input.GetAxis("Horizontal");
    // Debug.Log($"xAxis: {xAxis}");
    float zAxis = Input.GetAxis("Vertical");
    Debug.Log($"zAxis: {zAxis}");

    Vector3 movement = new Vector3(xAxis, 0, zAxis);
    transform.Translate(movementSpeed * Time.deltaTime * movement);

    transform.eulerAngles = new Vector3(0, virtualCamera.transform.eulerAngles.y, 0);

    if (Input.GetAxis("Vertical") >= deadZone)
    {
      animator.ResetTrigger("onStop");
      animator.ResetTrigger("onBackwards");
      animator.SetTrigger("onWalk");
    }
    else if (Input.GetAxis("Vertical") <= -deadZone)
    {
      animator.ResetTrigger("onStop");
      animator.ResetTrigger("onWalk");
      animator.SetTrigger("onBackwards");
    }
    else
    {
      animator.SetTrigger("onStop");
    }
  }
}
