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
    
    // -- FEILDS SET IN INSPECTOR
    
    [SerializeField]
    private int sphereMaximumHealth; // need to be hit by 10 missiles to be cracked

    [SerializeField]
    private float movementForce, reboundForce, maxReboundDistance; // variables controlling sphere movement

    // -- PRIVATE FEILDS

    private float timeAlive;
    private int timesHitByBullets = 0;
    private bool isCracked = false;
    private bool hasHitTank = false;
    private Vector3 positionDifference;

    // -- COMPONENT REFERENCES

    private Rigidbody myRigidbody;
    public GameObject myTarget;
    private Collider myCollider;
    
    // --  UNITY METHODS

    void Awake() // Initialise Component References
    {
        myRigidbody = GetComponent<Rigidbody>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
        myCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision) // detect if player is hit to trigger rebound.
    {
        if (collision.collider.CompareTag("Player"))
        {
            hasHitTank = true;
            Debug.Log(hasHitTank);
        }
    }

    void FixedUpdate() // Update is called once per frame
    {
        positionDifference = myTarget.transform.position - transform.position;
        if (hasHitTank)
        {
            Rebound();
        }
        else
        {
            Movement();
        }
    }

    void Movement() // move towards the player if not rebounding in FixedUpdate
    {
       myRigidbody.AddForce(positionDifference * movementForce); 
    }

    void Rebound() // if sphere touches the player rebound off till rebound distance reached.
    {
        var rebound = positionDifference * reboundForce;
        myRigidbody.AddForce(-rebound);

        if (positionDifference.magnitude >= maxReboundDistance)
        {
            Debug.Log("I've reached rebound distance");
            hasHitTank = false;
        }

    }

}
