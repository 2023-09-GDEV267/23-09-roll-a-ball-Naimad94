using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Added new namespace.
using TMPro; //Added new namespace/ import package.

/**
*   4 namespaces above are: System.Collections, System.Collections.Generic,
*   UnityEngine and now UnityEngine.InputSystem.
**/

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //Should be accessible and visible in the inspector module becuase it was set to public.

    public TextMeshProUGUI countText;
    public GameObject winTextObject;


    //private variables will not be accessible from the inspector in Unity or other scripts.
    private Rigidbody rb; //creates a private variable type Rigidbody called rb.

    private int count; //becuase it's private will not be able to manipulate in the inspector module.
    

    //float is used for precision then whole number or integer value.
    private float movementX;
    private float movementY;

    /** 
    *   Is it possible to write it like: private float movementX,movementY;
    **/

    // Start is called before the first frame update
    void Start() //when game starts.
    {
        rb = GetComponent<Rigidbody>(); //sets value of variable rb by getting refrence to the Rigidbody component attached to the playersphere GameObject.
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    //Created function declaration (aka method?).
    //movementValue is name of the variable used within the function.
    //InputValue is the type of variable.
    //movementValue will store capture and store data of x and y direction.
    //this type of data will be stored as a vector 2 variable.
    void OnMove(InputValue movementValue)
    //Function body (method body/block?)
    {
        /** 
        *   code takes vector2 data from movementValue and stores it in
        *   vector2 variable created called movementVector.
        **/

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //This function must be called after the line of code setting the count variable's value within the start function.
    //Count needs to have a value that can be used to set the UI Text.
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 3)
        {
            winTextObject.SetActive(true);
        }
    }

    //FixedUpdate is called just before performing physics calculations(Physics code).
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //f signifies it's a float value.
        
        rb.AddForce(movement * speed); //were multiplying the force.
    }

    //OnTriggerEnter will be called by Unity when the player GameObject first touches a trigger collider.
    //It will be given a refrence to the trigger collider that has been touched.
    //That is the collider called "other".
    //This refrence gives you a way to identify the colliders that the GameObject hits.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp")) //PickUp is the comparison in this case.
        {
            other.gameObject.SetActive(false); //To disable it we used the method setActive which only accepts boolean value inside the parenthesis.
            count = count + 1; //can be written in count =+ 1??

            SetCountText(); //Will update UI Component text everytime the count variable is incremented after the player collects the cube.
        }
    }
}





/**
*  NOTES:
*  void means function wont return any values.
*  Variables can store different types of data.(Variables are int, string...)
*  
**/

/** 
*   Functions are start and update.
*   Update is called once per frame.
*   Update: Before rendering a frame.
*   Vector3 Variables stores data accross 3 axis (X,Y,Z so im guessing that mean 3D)
*   Vector2 I'm guessing is for 2 axis? (X and Y (2D))
**/

//OnTriggerEnter function allows detection and test collision on players GameObject collider.
//OnTrigger function will detect the contact between the player GameObject and the pickup GameObjects without creating a physical collision.

//Compare Tag can compare the tag of any GameObject to a string value ("PickUp").

/** Any gameobject with collider and rigidBody is considered dynamic so unity wont treat is as static or stationary. 
*   If it was static it would take unity longer each frame to calculate the phgysics and it would do this each frame
*   because the cubes are constantly rotating.
**/
