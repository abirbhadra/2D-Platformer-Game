using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
     [SerializeField] private float distance = 5f;

     public bool movingRight = true;
     public Transform groundDetection;

     public void Update()
     {
         transform.Translate(Vector2.right * speed * Time.deltaTime);
         RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, distance);
        //Debug.DrawRay(Ray.groundInfo);
         if(groundInfo.collider == false)
         {
             if(movingRight == true)
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
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();

        }

    }
    
    
}

