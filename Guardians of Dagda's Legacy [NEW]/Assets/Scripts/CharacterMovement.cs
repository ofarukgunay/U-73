using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Yürüme ve koþma hýzý
    public float runSpeedMultiplier = 2f; // Koþma hýzý çarpaný
    public float jumpForce = 4f; // Zýplama kuvveti
    public float gravity = -10f; // Yere düþme hýzý
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
        // Yere basýldýðýný kontrol et
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Yere basýldýðýnda hafif bir yere bastýrma gücü uygula.
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Koþma hýzý kontrolü
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= moveSpeed * runSpeedMultiplier;
        }
        else
        {
            moveDirection *= moveSpeed;
        }

        // Karakteri düþürme ve zýplama iþlemleri
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
