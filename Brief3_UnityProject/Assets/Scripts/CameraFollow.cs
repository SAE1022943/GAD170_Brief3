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
    
    // reference to the cameraobject script is attached to
    private Camera myCam;

    // What Object does the camera look at
    private GameObject cameraTargetObject;

    // Setup the camera's initial target
    private void Awake()
    {
        myCam = GetComponent<Camera>();
        cameraTargetObject = GameObject.FindGameObjectWithTag("Player");
    } 
   

    // Where should the camera be in relation to the target
    [SerializeField]
    private Vector3 positionalOffset = new Vector3(0, 20, -10);
    // private Vector3 rotationalOffset = new Vector3();

      
    private Vector3 currentPoint;
    
    private void CurrentMouseWorldPosition() 
    {                
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            currentPoint = hit.point;
        }
    }
    
    




   // Start is called before the first frame update
    void FollowTarget()
    {
        transform.position = cameraTargetObject.transform.position + positionalOffset;
        transform.LookAt(cameraTargetObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMouseWorldPosition();        
        if(cameraTargetObject != null) {FollowTarget();}
    }
}
