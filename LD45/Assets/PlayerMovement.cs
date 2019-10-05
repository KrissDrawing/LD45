using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private string state = "none";

    public float moveSpeed;
    public float jumpForce;
    public CharacterController characterController;


    public Vector3 moveDirection;
    public float gravityScale;


    private float planeAcceleration=0;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "flying")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                planeAcceleration += 0.06f;
            }
            else
            {
                planeAcceleration = 0;
            }

            movementY += planeAcceleration + (Physics.gravity.y * 0.1f);


            transform.Translate(10 * Time.deltaTime, movementY * Time.deltaTime, 0);
           
            //TurnOnMoving();
        }

        if (state == "moving")
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }


            moveDirection.y += Physics.gravity.y * gravityScale;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    public void TurnOnFlying()
    {
        animator.enabled = !animator.enabled;
        state = "flying";
       
    }

    public void TurnOnMoving()
    {
       state = "moving";

    }
}
