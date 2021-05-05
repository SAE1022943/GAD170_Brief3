using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the tank's movement.
/// It requires a rigidbody and a camera in the scene
/// It will use the screenpointtoray function to find where the user is pointing
/// 
/// 
/// </summary>

public class TankMotor : MonoBehaviour
{


    // --- fields set by the controller.

    // Reference to the camera's oriting 
    private OctahedronController myController;      
    private Rigidbody myRigidBody;
    private Camera myCam;  
    
   
    private Vector3 currentTargetPoint;


    /// <summary>
    /// Initialize references and components
    /// </summary>
    private void Awake()
    {       
        myRigidBody = gameObject?.GetComponent<Rigidbody>();
        myCam = Camera.main;

    }

    /// <summary>
    /// Move the tank with the appropriate force
    /// </summary>
    private void Move()
    {

        // 1 Get the Mouse location in world space by raycasting

        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Floor");

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, mask))
        {
            currentTargetPoint = hit.point;
        }

        // 2 find the difference betwene the tank and the target point

        var diff_PointToTank = currentTargetPoint - transform.position;

        // 3 then add force if outside the specificed stop range


        // 
        if (diff_PointToTank.magnitude > stopRange)
        {
            myRigidBody.AddForce(diff_PointToTank + (myController.movementForce * diff_PointToTank.normalized));
        }
        else
        {
            myRigidBody.velocity = Vector3.zero;
        }

    }

    private void Stop()
    {






    }






    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        
    }
}
