using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 
/// Logic for missile.
/// Get a target from the PlayManager
/// Move the missile towards the target.
/// On collision with target, tell that object to take damage
/// Deactivate the missile 
///  
/// </summary>

public class Missile : MonoBehaviour
{
    // INSPECTOR SET FIELDS

    [SerializeField]
    private float missileForce;

    // Component References - none atm

    // PRIVATE FIELDS

    // Object References

    private GameObject target;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Debug.Log("Moving");
    }
    
}
