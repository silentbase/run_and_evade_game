using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //variabeln fuer die Simulation der Schwerkraft
    private float verticalVelocity;
    private float gravity = 94.0f;
    private float jumpForce = 45.0f;

    //steile flaeschen
    private float slopeForce = 1000;
    private float slopeForceRayLength;

    private GameObject player;

    private float speed = 50;

    private CharacterController characterController;

    //public Transform cam;
    public Transform cam;

    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("Player");
        characterController = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hMove,0,vMove).normalized;
        
        if(move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
            
            if(hMove > 0.1f)
            {
                cam.rotation = Quaternion.Euler(player.transform.forward);
            }

        }


        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }


        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(jumpVector * Time.deltaTime);
    

        if((hMove != 0 || vMove != 0) && OnSlope())
        {
            characterController.Move(Vector3.down * characterController.height / 2 * slopeForce
                * Time.deltaTime);
        }
    }

    private bool OnSlope()
    {
        

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, characterController.height/2 * slopeForceRayLength))
        {
            if(hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
    void Jump()
    {
        characterController.Move(new Vector3(0, 6, 0));
    }

    private void FixedUpdate()
    {

        //rb.velocity = new Vector3(horizontalMov, 0, verticalMov);


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("obstacle"))
        {
            ScreenManager.gameOver = true;
        }
    }
}
