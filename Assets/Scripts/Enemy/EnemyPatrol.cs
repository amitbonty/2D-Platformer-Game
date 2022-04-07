using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float distance;
    [SerializeField]
    Transform groundDetector;
    [SerializeField]
    Animator animator;
    private bool movingRight = true;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.PlayerDamaged();
            SoundManager.Instance.Play(Sounds.PlayerHurt);
        }
    }
}
