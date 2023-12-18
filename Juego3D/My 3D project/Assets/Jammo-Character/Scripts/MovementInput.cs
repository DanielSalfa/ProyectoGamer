using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{
    public float Velocity;
    [Space]

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float jumpForce = 8.0f;
    public float gravity = 30.0f;
    public int maxJumps = 2;

    private int jumpsRemaining;
    private bool isJumping = false;
    private float verticalVel = 0f;
    private Vector3 moveVector;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        InputMagnitude();

        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
            verticalVel = -gravity * Time.deltaTime;

            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            verticalVel -= gravity * Time.deltaTime;

            // Check for double jump input
            if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        moveVector = new Vector3(0, verticalVel * Time.deltaTime, 0);
        controller.Move(moveVector);
    }

    void Jump()
    {
        isJumping = true;
        verticalVel = jumpForce;
        jumpsRemaining--;
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (!blockRotationPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
        }
    }

    void InputMagnitude()
    {
        // Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        // Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        // Physically move player
        if (Speed >= allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
    }
}
