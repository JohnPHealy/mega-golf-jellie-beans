using UnityEngine;
using UnityEngine.Events;


public class BallMovement: MonoBehaviour 
{
    [SerializeField] private float shotPower, maxForce, minSpeed;

    private Rigidbody myRB;
    private float shotForce;
    private Vector3 startPos, endPos, direction;
    private bool canshoot, shotStarted;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
        canshoot = true;
        myRB.sleepThreshold = minSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canshoot)
        {
            startPos = MousePositionInTheWorld();
            shotStarted = true;
        }

        if (Input.GetMouseButton(0) && shotStarted)
        {
            endPos = MousePositionInTheWorld();
            shotForce = Mathf.Clamp(Vector3.Distance(endPos, startPos), 0, maxForce);

        }

        if (Input.GetMouseButtonUp(0) && shotStarted)
        {
            canshoot = false;
            shotStarted = false;
        }

    }

    private void FixedUpdate()
    {
        if (!canshoot)
        {
            direction = startPos - endPos;
            myRB.AddForce(Vector3.Normalize(direction) * shotForce * shotPower, ForceMode.Impulse);
            startPos = endPos = Vector3.zero;
        }

        if (myRB.IsSleeping())
        {
            canshoot = true;
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
