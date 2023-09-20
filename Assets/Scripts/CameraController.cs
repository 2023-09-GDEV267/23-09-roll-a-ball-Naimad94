using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Two variables declqarations created.
    
    public GameObject player; //public gameobject refrence to the player object.
    
    private Vector3 offset; //holds offset value. This variable is private because value will be set with in the script.


    // Start is called before the first frame update
    //Code needs to happen immediatly which is why it's in the start method.
    void Start()
    {
        offset = transform.position - player.transform.position; //will set offset = camera transform pos. minus the player gameobject transform position.
        
    }

    // LateUpdate: Runs every frame but will run after all other updates are down.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //matches the position but not the rotation of the sphere.
        
    }
}


/**
*   LateUpdate is good for gathering task and following updates.
**/