using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float space;
    float horizontalAD;
    float horizontalWS;
    [SerializeField] private Transform groundcheck;
    public float mousesensitivity = 60;
    public Transform playerBody;
    public Transform playerView;
    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get A or D 
        if (Input.GetKey(KeyCode.D))
        {
            horizontalAD = 5;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalAD = -5;
        }

        // get W or S 
        if (Input.GetKey(KeyCode.W))
        {
            horizontalWS = 5;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            horizontalWS = -5;
        }


        // ground check
        if (Physics.OverlapSphere(groundcheck.position, 0.1f).Length ==1)
        {
            return;
        }

 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            space = 10;

        }

        
    }
    private void FixedUpdate()
    {
     
        




        // move left and right

        GetComponent<Rigidbody>().velocity = transform.right*horizontalAD + transform.forward*horizontalWS + transform.up*space ;
        horizontalAD = 0;
        horizontalWS = 0;
        space = 0;

  


      




    }

}
