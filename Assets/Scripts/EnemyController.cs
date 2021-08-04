//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyController : MonoBehaviour
//{
//    public float speed;
//    private float waitTime;
//    public float startWaitTime;
//    public Transform[] moveSpots;
//    private int randomSpot;
//    public Animator animator;
//    public bool isFlipped;
//    private void Start()
//    {
//        waitTime = startWaitTime;
//        randomSpot = Random.Range(0, moveSpots.Length);
//    }
//    private void Update()
//    {
//        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
//        animator.SetBool("isWalking", true);
//        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.02f)
//        {
//            if (isFlipped)
//            {
//                Vector3 scale = transform.localScale;
//                scale.x = -1f * scale.x;
//                transform.localScale = scale;
//                isFlipped = false;
//            }
//            //if (transform.localScale.x < 0)
//            //{
//            //    transform.localScale = new Vector3(1, 1, 1);
//            //}
//            if (waitTime <= 0)
//            {
//                animator.SetBool("isWalking", false);
               
//                randomSpot = Random.Range(0, moveSpots.Length);
//                waitTime = startWaitTime;
//                isFlipped = true;
//                Debug.Log("Wait time starter!");
//            }
//            else
//            {
//                waitTime --;
//                Debug.Log("Moved!");
//                Debug.Log(waitTime);
                
//            }
//        }
//        else if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) == 0.021f)
//        {
           
            
//        }
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.GetComponent<PlayerController>())
//        {
//            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
//            playercontroller.PlayerDamaged();
           
//        }
//    }
//}
