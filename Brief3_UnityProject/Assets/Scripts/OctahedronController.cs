using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This class is the Controller for my tank.
///  
/// Movement:
///     Tank will move towards the point the mouse is pointing at.
///     
/// 
/// 
/// 
/// 
/// </summary>



public class OctahedronController : MonoBehaviour
{

    public int timesHitBySphere = 0;

    // how fast the tank moves
    [SerializeField] 
    private float movementSpeed, rotationSpeed; // how fast the tank moves and rotates towards the currentTargetPoint
    
    // PRIVATE FIELDS
    private Rigidbody myRigidBody;
    private Collider myCollider;
    private Camera myCam;

    // Where is the player pointing with the mouse
    private Vector3 currentTargetPoint;
    


    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        myCam = Camera.main;
    }

    private void Movement()
    {
              
        // 1 Get the Mouse location in world space 
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            currentTargetPoint = hit.point;
        }

        // 2 find the difference betwene the tank and the target point
        var diff_PointToTank = currentTargetPoint - transform.position;
        myRigidBody.AddForce(diff_PointToTank + (movementSpeed * diff_PointToTank.normalized));
        






       
                          
    }


    private void FixedUpdate()
    {
        Movement();

    }

}
