using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

 /* Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 200, 500);
    }*/


public class PlayerMovement1 : MonoBehaviour
{   
    //referance for component rb in rigidbody.
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewayForce = 500f;

    // Update is called once per frame
    // "Fixed"Update, are using to mess with physics.
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey("a") ){
            rb.AddForce(-sidewayForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("d") ){
            rb.AddForce(sidewayForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;

            if (touch.position.x < middle)
            {
                rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (touch.position.x > middle)
            {
                rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        

        if(rb.position.y < -1f){
            FindObjectOfType<Manager>().EndGame();
        }

    }
}
