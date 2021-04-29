using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This class is the Controller for my tank. 
/// I'm trying to adhere to the single responsibility rule, but realize composition in unity is using components.
/// So really should put my movement logic in a movement script then in this controller, require that script then pass the fields into that class.
/// Thus use the same movememnt script for both tank and spheres and maybe my bullets.
/// 
/// 
/// What the script does
/// 
/// Movement():
///     Tank will move towards the point the mouse is pointing at on the floor.
///     Force will stop being applied to to the object when it's within a minimum distance to that point
///     
/// OnCollision();     
///     if the tank is hit by an Sphere it'll add that to it's times hit count, which will trigger death.
///     
/// Killed(); 
///     Notify the PlayManager that the player is dead and stop the game.
/// 
/// 
/// </summary>



public class OctahedronController : MonoBehaviour
{

    // -- FEILDS SET IN THE INSPECTOR

    [SerializeField]
    private int maxTankHealth, maxMissileCapacity; // Takes ten hits to kill tank
    [SerializeField]
    private float movementForce, stopRange; // move with this force and stop when tank cursor distance is within stoprange.
    [SerializeField]
    private float shootingDelayInSeconds;

    // -- DELEGATES AND EVENTS

    public delegate void GameBehaviour(); 
    public static GameBehaviour TankDeath;
    

    // -- COMPONENT REFERENCES
    
    private Rigidbody myRigidBody;
    private Camera myCam;
    public GameObject missileRef;

    // -- PRIVATE FEILDS

    private Vector3 currentTargetPoint;
    private int currentTankHealth = 0;
    private int missileReserves;





    // --  UNITY METHODS

    private void Awake() // initialize references
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCam = Camera.main;
    }

    public void OnEnable() // add event listeners
    {
        MunitionPickUp.PickedUp += AddMissiles;      
    }

    public void OnDisable() // remove event listeners
    {
        MunitionPickUp.PickedUp -= AddMissiles;
    }

    private void Start() // initialize variables
    {
        currentTankHealth = maxTankHealth; // the tank starts at full health

        StartCoroutine("Shoot");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            currentTankHealth--;
            //Debug.Log("ouch, health at " + currentTankHealth);

            if(currentTankHealth <= 0)
            {
                Died();
            } 
        }

    }

    private void FixedUpdate()
    {
        Movement();
    }

    // -- CREATED METHODS

    private void Movement()
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

        if (diff_PointToTank.magnitude > stopRange)
        {
            myRigidBody.AddForce(diff_PointToTank + (movementForce * diff_PointToTank.normalized));
        } 
        else
        {
            myRigidBody.velocity = Vector3.zero;
        }

    }
    
    /// <summary>
    /// Listen for the PickeUp event in PowerUpPickUp then add passed ammo 
    /// if added amount exceeds the max, then set to max missiles.
    /// </summary>
    /// <param name="_ammo"></param>
    private void AddMissiles(int _ammo) 
    {
        missileReserves += _ammo;
        if (missileReserves > maxMissileCapacity) { missileReserves = maxMissileCapacity; }
        Debug.Log("Missile remaining is " + missileReserves);
    }

    IEnumerable Shoot() // gun always shoots ever 5 seconds. Select a missile battery to shoot.
    {
        Debug.Log("Bang!");
        yield return new WaitForSeconds(shootingDelayInSeconds);
    }

    private void Died()
    {
        
        Debug.Log("Tank go bye bye!");
        Destroy(this);
    }
}
