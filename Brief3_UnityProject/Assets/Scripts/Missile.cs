using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Logic for missile.
/// 
/// Move the missile towards the target.
/// 
/// On collision with target, tell that object to take damage
/// 
/// Deactivate the missile 
///  
/// </summary>

public class Missile : MonoBehaviour
{

    // INSPECTOR SET FIELDS

    [SerializeField]
    private float missileForce = 50f; // make them go fast so they hit. 

    // PRIVATE FIELDS

    private GameObject myTarget;
    private Rigidbody myRigidBodyRef;

    private Vector3 distanceToTarget;
    
    // METHODS

    // --- Unity Methods 

    private void Awake()
    {
        myRigidBodyRef = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy")) // Enemy prefab is marked with this tag
        {            
            
            gameObject.SetActive(false); // deactivate the missile, avoiding instantiation 

        }

    }

    void FixedUpdate()
    {
        MoveToTarget();
    }

    // --- Custom Methods

    /// <summary>
    /// move the missile towards the target.
    /// </summary>
    void MoveToTarget()
    {
        distanceToTarget = myTarget.transform.position - transform.position; 
        myRigidBodyRef.AddForce(myTarget.transform.position + (missileForce * distanceToTarget.normalized));
    }
    
}
