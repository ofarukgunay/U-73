using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Y�r�me ve ko�ma h�z�
    public float runSpeedMultiplier = 2f; // Ko�ma h�z� �arpan�
    public float jumpForce = 4f; // Z�plama kuvveti
    public float gravity = -10f; // Yere d��me h�z�
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Yere bas�ld���n� kontrol et
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Yere bas�ld���nda hafif bir yere bast�rma g�c� uygula.
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Ko�ma h�z� kontrol�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= moveSpeed * runSpeedMultiplier;
        }
        else
        {
            moveDirection *= moveSpeed;
        }

        // Karakteri d���rme ve z�plama i�lemleri
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime + playerVelocity * Time.deltaTime);
    }
}
