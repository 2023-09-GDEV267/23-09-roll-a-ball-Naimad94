using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        /**
        *   Rotate the game Object that this script is attached by 15 in the X axis,
        *   30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it up per second
        *   rather than per frame.
        **/

        //this has two initial parameters, one using a Vector3 variable and the other using three float values for (X, Y and Z).
        //Using Vector3 parameter.
        //For smoothness and framerate dependent we multiply by deltaTime.
        transform.Rotate (new Vector3 (15, 30, 45) * deltaTime);
        
    }
}

/**
*  Wont be using forces so we used update instead of FixedUpdate
**/

//Translate and Rotate can effect transform of a game object.
//Translate: moves the GameObject by it's transform in the inspector module.
//Rotate: rotates the GameObject by it's transform in the inspector modue.

/**
*  deltaTime is perfect for ensuring actions happen smoothly because it is a float representing the difference in seconds since the last frame update occured.
*  This will dynamically change it's value based on the length of a frame.
**/