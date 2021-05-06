using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the Controller for my tank.
/// It makes sure that all the require components are added and set to correct values defined in it's inspector
/// I handles health and ammo data as well, and collisions.
/// </summary>

public class OctahedronController : MonoBehaviour
{
   
    // -- FEILDS SET IN THE INSPECTOR

    private int maxTankHealth, maxMissileCapacity; // Takes ten hits to kill tank

    private float movementForce;
    public float getMovementForce()
    {
        get { return movementForce; }
    }

    private float stopRange;
    public float getStopRange()
    {
        return stopRange;
    }

    // -- REFERENCES

    private MissileBattery myBattery;
    private TankMotor myMotor;


    // -- DELEGATES AND EVENTS


    public delegate void TankState(); // state notifications.
    public static event TankState TankDeath;
        
    // -- PRIVATE FEILDS
    
    private int currentTankHealth; 
    private int currentMissiles;

    // --  UNITY METHODS

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        myBattery = gameObject?.AddComponent<MissileBattery>();
        myMotor = gameObject?.AddComponent<TankMotor>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnEnable() // add event listeners
    {
        MunitionPickUp.PickedUp += AddMissiles;
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDisable() // remove event listeners
    {
        MunitionPickUp.PickedUp -= AddMissiles;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start() // initialize variables
    {
        currentTankHealth = maxTankHealth; // the tank starts at full health
        currentMissiles = maxMissileCapacity; // and with max missiles
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            if (currentTankHealth == 0)
            {
                Died();
            } 
            else
            {
               currentTankHealth--;
            }
        }

    } // spheres damage tank

    // -- CREATED METHODS
          
    /// <summary>
    /// 
    /// Listen for the PickeUp event in PowerUpPickUp then add passed ammo 
    /// if added amount exceeds the max, then set to max missiles.
    /// 
    /// </summary>
    /// <param name="_ammo"></param>
    private void AddMissiles(int _ammo) 
    {
        currentMissiles += _ammo;
        if (currentMissiles > maxMissileCapacity) { currentMissiles = maxMissileCapacity; }
        Debug.Log("Missile remaining is " + currentMissiles);
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    private void Died()
    {
        Debug.Log("Tank go bye bye!");
        TankDeath?.Invoke();
        Destroy(gameObject);
    }
}
