using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rb;
    public float jump;
    public bool isGrounded;
    public float vertical;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    public void Update()
    {
        float moveSpeed = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");

        PlayerFlip(moveSpeed);
        PlayerMovement(moveSpeed, vertical);
        PlayerJump(vertical);
        PlayerCrouch();
    }
    public void FixedUpdate()
    {
       
    }
    public void PlayerMovement(float moveSpeed, float vertical)
    {
        //move player horizontally
        Vector3 position = transform.position;
        position.x += moveSpeed * speed * Time.deltaTime;
        transform.position = position;

        //move player vertically
        if (vertical > 0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
    public void PlayerFlip(float moveSpeed)
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(moveSpeed));
        Vector3 scale = transform.localScale;
        if (moveSpeed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (moveSpeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void PlayerJump(float vertical)
    {
      animator.SetBool("Jump", Input.GetKey(KeyCode.Space));
    }
    public void PlayerCrouch()
    {
      animator.SetBool("Crouch", Input.GetKey(KeyCode.C));
    }
}
