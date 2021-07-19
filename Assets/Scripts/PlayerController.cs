using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public void Update()
    {
        PlayerFlip();
    }
    public void PlayerFlip()
    {
        float moveSpeed = Input.GetAxisRaw("Horizontal");
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
}
