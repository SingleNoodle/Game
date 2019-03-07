using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    float jump = 2;
    float turnSpeed = 15;
    bool isgrounded;

    public static Rigidbody playerRigid;
    public static GameObject playerObject;
    public static Transform playerTran;

    Transform cam;
    GameObject ground;

    Vector2 input;
    float angle;
    Quaternion targetRotation;

    Animator anim;

    void Start()
    {
		cam = Camera.main.transform;

		playerRigid = GetComponent<Rigidbody>();
        playerTran = GetComponent<Transform>();
        playerObject = GetComponent<GameObject>();
        anim = GetComponent<Animator>();                //exist, getting value of Animator. Referencing Compenet AC

        playerRigid.freezeRotation = true;                     //flop like fish
        Physics.gravity = new Vector3(0, -10);
    }
    
    void FixedUpdate()
    {
        GetInput();

        Animate(input.x, input.y);

        //Jump();

        if (Mathf.Abs(input.x) > 0  || Mathf.Abs(input.y) > 0 )
        {
            CalculateDirection();
            Rotate();
            Move();
        }
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    } 

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isgrounded)
        {
            playerRigid.velocity = new Vector3(0, jump, 0);
            isgrounded = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        ground = GameObject.FindGameObjectWithTag("floor");
        if (collision.gameObject == ground)
        {
			isgrounded = true;
        }
        
    }
    void Animate(float x, float y)
    {
        bool Moving = x != 0f || y != 0f;

        anim.SetBool("Moving", Moving);
    }

}
