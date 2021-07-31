using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rb;
    public float jump;
    public bool isGrounded;
    public float vertical;
    public GameManager gameManager;
    public int PlayerLives;
    public GameObject Heart1 ,Heart2, Heart3;

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
        float moveSpeed = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");

        PlayerFlip(moveSpeed);
        PlayerMovement(moveSpeed, vertical);
        PlayerJump(vertical);
        PlayerCrouch();
        PlayerHealth();
    }
   public void KeyPickup()
    {
        Debug.Log("Player Picked Up Key!");
        gameManager.IncreaseScore();
        
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
           /* rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);*/
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
        Debug.Log("Player Hurt!");
        PlayerLives--;
        //animator.SetBool("isDead", true);
        //ReloadLevel();
    }
    public  void PlayerDeath()
    {
        if(PlayerLives <= 0)
        {
            gameManager.GameOver();
            this.enabled = false;
        }
    }
   
    public void PlayerHealth()
    {
        switch (PlayerLives)
        {
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
               
                break;
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                PlayerDeath();
                break;
        }
            
             
    }
}
