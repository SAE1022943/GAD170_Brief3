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
    private float movementSpeed, reboundForce, maxReboundDistance;


    private float timeAlive;

    private int timesHitByBullets = 0;
    
    private bool isCracked = false;

    private Rigidbody myRigidbody;
    public GameObject myTarget;
    private Collider myCollider;

    public bool hasHitTank = false;
    
    private Vector3 positionDifference;  

    // Initialise all values
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myCollider = GetComponent<Collider>();
    }

    void Movement()
    {
       myRigidbody.AddForce(positionDifference * movementSpeed); 
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.CompareTag("Player"))
        {
            hasHitTank = true;
            Debug.Log(hasHitTank);
        }

    }

    void Rebound()
    {
        var rebound = positionDifference * reboundForce;
        myRigidbody.AddForce(-rebound);

        if (positionDifference.magnitude >= maxReboundDistance)
        {
            Debug.Log("I've reached rebound distance");
            hasHitTank = false;
        }

    }

    private void Update()
    {
        positionDifference = myTarget.transform.position - transform.position; // enemy location minus tank location    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (hasHitTank)
        {
            Rebound();
        } 
        else
        {
            Movement();
        }

    }
}
