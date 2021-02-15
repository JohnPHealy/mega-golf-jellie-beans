using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
  [SerializeField] private float shotPower;

  private Rigidbody myRB;
  private float shotForce;
  private Vector3 startpos, endpos, direction;
  private bool canShoot;

  private void Start()
  {
    myRB = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      startpos = MousePositionInTheWorld();
    }

    if (Input.GetMouseButton(O))
    {
      endpos = MousePositionInTheWorld();
    }

    if (Input.GetMouseButtonUp(0))
    {
      canShoot = false;
    }
  }

  private Vector3 MousePositionInTheWorld()
  {
    Vector3 position = Vector3.zero;
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit = new RaycastHit();
    if (Physics.Raycast(ray, out hit))
    {
      position = hit.point;
    }

    return position;
  }
}
