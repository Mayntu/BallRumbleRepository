using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;

    [SerializeField] private float staminaMax;
    [SerializeField] public float stamina;
    private bool isSprinting = true;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator= GetComponent<Animator>();

        originalStepOffset = characterController.stepOffset;
    }

    private void Update()
    {

        if (!isLocalPlayer) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(-horizontalInput, 0, -verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * movementSpeed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime * 3;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        Sprint();
        Animation(movementDirection);
        if (stamina >= 0)
        {

        }
    }

    private void Sprint()
    {
        if (Input.GetKey("left shift") && isSprinting == true)
        {
            movementSpeed = sprintSpeed;
            stamina -= Time.deltaTime;
        }
        else
        {
            movementSpeed = walkSpeed;
            if(stamina<=staminaMax) stamina += Time.deltaTime;
        }
    }

    private void Animation(Vector3 mD)
    {
        if (mD == Vector3.zero)
        {
            animator.SetFloat("speed", 0);
        }
        else if (movementSpeed == sprintSpeed)
        {
            animator.SetFloat("speed", 0.6f);
        }
        else if (movementSpeed == walkSpeed)
        {
            animator.SetFloat("speed", 0.4f);
        }
    }
}
