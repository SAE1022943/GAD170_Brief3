using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to implement the tank's pulse ability, it is attached to the tank prefab and is controlled via the tank controller.
/// 
/// First shoot a sphere cast at current position that move outwards to a maximum range.
/// Anything hit within a minimum range will get pushed backwards
/// If a sphere is in the 'Cracked' it will be deactivated and a Missile pick up will spawn.
/// 
/// </summary>

public class MissileBattery : MonoBehaviour
{


    // -- COMPONENT REFERENCES


    private float shootingDelayInSeconds;

    private IEnumerator shootSalvo; // reference is needed to do a is null check.

    private List<GameObject> targetsToShoot; // this list is aquired set from the 



    private void Awake() // initialize references
    {
        shootSalvo = Shoot();
    }


    // Start is called before the first frame update
    void Start()
    {

        if (shootSalvo != null) // null check before setting coroutine reference
        {
            StartCoroutine("Shoot");
        }


    }


    /// <summary>
    /// This coroutine controls when the Octohedron shoots it's missile battery
    /// </summary>
    /// <returns></returns>
    IEnumerator Shoot() // gun always shoots ever 5 seconds. Select a missile battery to shoot.
    {




        Debug.Log("Bang!");
        yield return new WaitForSeconds(shootingDelayInSeconds);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
