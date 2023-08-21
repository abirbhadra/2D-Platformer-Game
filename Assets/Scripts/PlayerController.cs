using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool run ;
    private bool crouch;
    private bool jump;

    public Animator animator;
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed<0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale; // here transforming the scale with new scale value we got

        animator.SetBool("Run", run );//Run animation
        if (Input.GetKeyDown(KeyCode.LeftShift))
            run = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            run = false;

        animator.SetBool("Crouch", crouch);//Crouch Animation
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch = true;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            crouch = false;

        animator.SetBool("Jump", jump);//Crouch Animation
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        if (Input.GetKeyUp(KeyCode.Space))
            jump = false;
    }
}
