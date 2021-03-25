using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField]private float _currentSpeed;
    [SerializeField] private float _walkSpeed = 12f;
    [SerializeField] private float _sprintSpeed = 20f;
    [SerializeField] private float _gravity = -12f;
    [SerializeField] private float jumpHeight = 4f;

    public Transform groundCheck;
    public float groundDisctance = 0.4f;
    public LayerMask groundMask;
    public bool isRunning = false;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        isRunning = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDisctance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * _currentSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity);
        }

       velocity.y += _gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && Input.GetKey(KeyCode.Z))
        {
            _currentSpeed = _sprintSpeed;
            isRunning = true;

        }
        else
        {
            _currentSpeed = _walkSpeed;
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 2.4f;
        }
        else
        {
            controller.height = 3.6f;
        }
    }
}
