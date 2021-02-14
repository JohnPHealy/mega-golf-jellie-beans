using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private float shotPower;
    
    private Rigidbody myRB;
    private Vector3 startPos, endPos, direction;
    private bool canShoot = true;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = MousePositionInWorld();
        }

        if (Input.GetMouseButton(0))
        {
            endPos = MousePositionInWorld();
        }

        if (Input.GetMouseButtonUp(0))
        {
            canShoot = false;
        }
    }

    private void FixedUpdate()
    {
        if (!canShoot)
        {
            direction = startPos - endPos; 
            myRB.AddForce(direction * shotPower, ForceMode.Impulse);
            startPos = endPos = Vector3.zero;
        }
    }

    private Vector3 MousePositionInWorld()
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
