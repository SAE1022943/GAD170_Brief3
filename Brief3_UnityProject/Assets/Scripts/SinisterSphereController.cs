using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 
/// This class handles the logic for the sinister spheres
/// 
/// Always move towards the tanks location.
/// 
/// If you hit the tank, rebound off it before chasing again.
/// 
/// 
/// </summary>

public class SinisterSphereController : MonoBehaviour
{
       
    
    [SerializeField]
    private int sphereMaximumHealth;

    [SerializeField]
    private float movementSpeed;

    private int timesHitByBullets = 0;  
    private float TotaldistanceTraveled = 0f;
    private bool isCracked = false;


    private Rigidbody myRigidbody;
    public GameObject myTarget;
    private Collider myCollider;

    // Initialise all values
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myCollider = GetComponent<Collider>();
    }


    void Movement()
    {
        var diff = myTarget.transform.position - transform.position; // enemy location minus tank location    
        myRigidbody.AddForce(diff + (movementSpeed * diff.normalized)); // move the enemy towards the player
    }
    
    
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
}
