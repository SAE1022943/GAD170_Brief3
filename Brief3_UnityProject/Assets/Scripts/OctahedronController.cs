using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 
/// This class is the Controller for my tank.
///  
/// Movement:
/// 
/// </summary>



public class OctahedronController : MonoBehaviour
{
    // PUBLIC FIELDS
      
    // how fast the tank moves
    public float maxMovementSpeed, maxRotationSpeed; 
   

    // PRIVATE FIELDS
    private Rigidbody myRigidBody;
    private Collider myCollider;
    private Camera myCamera;
             
    public Vector3 targetPoint; 
     


    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>(); 
        myCollider = GetComponent<Collider>();
        myCamera = Camera.main.GetComponent<Camera>();      
    }


    private void Movement()
    {
        // Find where the player is pointing with the mouse
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);      
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, 100f))
        {
           targetPoint = hit.point; // assign the point to mousePosition
        }

        


                

    }

    private void Update()
    {
        Movement();
    }

}
