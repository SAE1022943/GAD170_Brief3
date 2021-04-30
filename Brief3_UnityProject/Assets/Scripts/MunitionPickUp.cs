using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 
/// Script for my pickup objects. 
///  * When player touches trigger the pickup event invokes
///  * This will notify the tank to increase it's missile count
///  * Despawn after the timeAlive reaches zero
/// 
/// </summary>

public class MunitionPickUp : MonoBehaviour
{

    // --  FEILDS SET IN INSPECTOR

    [SerializeField]
    private int missileAmount; // how many missiles does the player tank recieve on pick up
    [SerializeField]
    private float timeAlive; // how long the powerup stays interactable

    // -- DELEGATES AND EVENTS

    public delegate void GameAction(int _ammo);
    public static GameAction PickedUp;

    // -- 

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Debug.Log("That tank touched me!");
            PickedUp?.Invoke(missileAmount);
        }

    }

    private void Update()
    {
    
    }


    IEnumerator DespawnTimer()
    {
         
        timeAlive++;
        return null;

    }







}
