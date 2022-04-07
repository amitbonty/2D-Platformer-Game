using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    float speed;
    private Rigidbody2D rb;
    [SerializeField]
    float jump;
    [SerializeField]
    bool isGrounded;
    [SerializeField]
    float vertical, moveSpeed;
    [SerializeField]
    int PlayerLives;
    [SerializeField]
    GameObject[] Hearts;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }
    private void Start()
    {
        PlayerLives = 3;
    }

    public void Update()
    {
        moveSpeed = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
        PlayerHealth();
        PlayerDeath();
    }
    private void FixedUpdate()
    {
        PlayerFlip(moveSpeed);
        PlayerMovement(moveSpeed, vertical);
        PlayerJump(vertical);
        PlayerCrouch();
    }
    public void KeyPickup()
    {
        GameManager.Instance.IncreaseScore();
    }
    public void PlayerMovement(float moveSpeed, float vertical)
    {
        Vector3 position = transform.position;
        position.x += moveSpeed * speed * Time.deltaTime;
        transform.position = position;
        if (vertical > 0)
        {
           Vector2 movement = new Vector2(rb.velocity.x, jump);
           rb.velocity = movement;
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
    public void PlayerDamaged()
    {
        PlayerLives--;
    }
    public  void PlayerDeath()
    {
        if(PlayerLives <= 0)
        {
            GameManager.Instance.GameOver();
            this.enabled = false;
        }
    }
   
    public void PlayerHealth()
    {
        Hearts[PlayerLives].gameObject.SetActive(false);
    }
}
