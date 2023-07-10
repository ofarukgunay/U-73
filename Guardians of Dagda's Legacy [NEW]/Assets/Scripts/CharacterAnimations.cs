using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private bool isJumping;
    private Animator animator;
    private bool isMoving;
    private bool isRunning;

    void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = false;
        isRunning = false;
        isJumping= false;
    }

    void Update()
    {
        // W, A, S, veya D tu�lar�na bas�l�rsa
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            animator.SetBool("isMoving", isMoving);
        }

        // W, A, S, veya D tu�lar�ndan herhangi biri b�rak�l�rsa
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
        //Space tu�una bas�l�rsa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
        //Space tu�u b�rak�l�rsa
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
        // E tu�una bas�l�rsa
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            isRunning = true;
            animator.SetBool("isRunning", isRunning);
        }
        // E tu�u b�rak�l�rsa
        if (Input.GetKeyUp(KeyCode.E))
        {
            isRunning = false;
            animator.SetBool("isRunning", isRunning);
        }
    }

}

