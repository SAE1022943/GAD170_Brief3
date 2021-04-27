using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// This Script handles the camera behavour.
/// The camera focuses on the player object.
/// 
/// 
/// 
/// 
/// </summary>




public class CameraFollow : MonoBehaviour
{


    // how should the camera follow the target
    public Vector3 positionalOffset = new Vector3(0, 20, -10);

    // what the camera is looking at
    private GameObject cameraTargetObject;
    
       
    private void Awake()
    {
        
       cameraTargetObject = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraTargetObject.transform.position + positionalOffset;
        transform.LookAt(cameraTargetObject.transform);
    }
}
