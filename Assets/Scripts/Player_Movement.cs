using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed ;
    public CharacterController characterController;
    public float turnSmoothTime =0.1f;
    float turnSmoothVelocity;
   //[SerializeField] public float movespeed = 2f;

    //Rigidbody was fucked up so i use character controller to add gravity manually
    public float gravity = 20f;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Moves. Me happy :)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal,0,vertical).normalized;
        var velocity = move;

        if(move.magnitude >= 0.1f){
            float targetAngel = Mathf.Atan2(move.x,move.z) * Mathf.Rad2Deg;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngel,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angel,0f);

            characterController.Move(speed*move*Time.deltaTime);

        }

        if (!characterController.isGrounded) //ground check
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
        

        playerAnim.SetFloat("Speed",velocity.magnitude);
    }

      
}

