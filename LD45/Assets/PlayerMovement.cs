using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public InventoryController inventory;

    public string state = "none";
    public float moveSpeed;
    public float jumpForce;
    public Vector3 moveDirection;
    public float gravityScale;


    private float planeAcceleration = 0;
    private float movementY;

    private CharacterController characterController;

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
            Vector3 currentAngle;
            if (Input.GetKey(KeyCode.Space))
            {
                planeAcceleration += 0.06f;

                currentAngle = new Vector3(
                    transform.rotation.x,
                    Mathf.LerpAngle(transform.rotation.eulerAngles.y, Random.Range(-30,30), Time.deltaTime * 20.0f),
                    Mathf.LerpAngle(transform.rotation.eulerAngles.z, -30, Time.deltaTime * 10.0f));
            }
            else
            {
                planeAcceleration = 0;
                 currentAngle = new Vector3(
                     transform.rotation.x,
                     Mathf.LerpAngle(transform.rotation.eulerAngles.y, Random.Range(-30, 30), Time.deltaTime * 5.0f),
                     Mathf.LerpAngle(transform.rotation.eulerAngles.z, 0, Time.deltaTime * 10.0f));
            }

            transform.eulerAngles = currentAngle;
            movementY += planeAcceleration + (Physics.gravity.y * 0.1f);

            transform.Translate(10 * Time.deltaTime, movementY * Time.deltaTime, 0, Space.World);
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

    void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "skills")
        {
            Debug.Log("KILIZJA");
            inventory.skills.Add(collision.gameObject); // Add some information about skill
            Destroy(collision.gameObject);
            
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
