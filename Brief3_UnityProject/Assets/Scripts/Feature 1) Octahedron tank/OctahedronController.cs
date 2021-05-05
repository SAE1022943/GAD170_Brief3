using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the Controller for my tank. 
/// I'm trying to adhere to the single responsibility rule, but realize composition in unity is using components.
/// So really should put my movement logic in a movement script then in this controller, require that script then pass the fields into that class.
/// Thus use the same movememnt script for both tank and spheres and maybe my bullets.
/// 
/// What the script does:
/// 
///     
/// OnCollision();     
///     if the tank is hit by an Sphere it'll add that to it's times hit count, which will trigger death.
///     
/// Died(); 
///     Notify the PlayManager that the player is dead and stop the game.
/// 
/// </summary>

public class OctahedronController : MonoBehaviour
{
   
    // -- 
    
    private MissileBattery myBattery;
    private TankMotor myMotor;
    
    // -- FEILDS SET IN THE INSPECTOR

    
    private int maxTankHealth, maxMissileCapacity; // Takes ten hits to kill tank
    
    
    private float movementForce, stopRange; // move with this force and stop when tank cursor distance is within stoprange.



    public float getMovementForce() 
    {
    
    }




   
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
