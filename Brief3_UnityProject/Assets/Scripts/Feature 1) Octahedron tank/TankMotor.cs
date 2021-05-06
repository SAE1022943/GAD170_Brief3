using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script handles the tank's movement.
/// It requires a rigidbody and a camera in the scene
/// It will use the screenpointtoray function to find where the user is pointing
/// 
/// 
/// NOTE:
/// 
/// I think maybe that the null exception operator won't work correctly with serialized fields, so I'll avoid that.
/// 
/// </summary>

public class TankMotor : MonoBehaviour
{

    // --- fields set by the controller.

    // Reference to the camera's oriting
    private OctahedronController myController;      
    private Rigidbody myRigidBody;
    private Camera myCam;  
    

    private float motorForce;
    public float SetMotorForce()
    {
        return gameObject.GetComponent<OctahedronController>().getMovementForce;
    }




    private Vector3 currentTargetPoint;


    /// <summary>
    /// Initialize references and components
    /// </summary>
    private void Awake()
    {
        myController = gameObject.GetComponent<OctahedronController>();
        myRigidBody = gameObject?.GetComponent<Rigidbody>();
        myCam = Camera.main;
    }
    
    private void GetUserMousePosition()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Floor");

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, mask))
        {
            currentTargetPoint = hit.point;
        }
    }

    /// <summary>
    /// Move the tank with the appropriate force
    /// </summary>
    private void Move()
    {
        var diff_PointToTank = currentTargetPoint - transform.position;
        myRigidBody.AddForce(diff_PointToTank + (myController.getMovementForce * diff_PointToTank.normalized));
    }

    private void Stop()
    {
        myRigidBody.velocity = Vector3.zero;
    }





    //private void Stop()
    //{
    //    if (diff_PointToTank.magnitude > myController.stopRange)
    //}
}
