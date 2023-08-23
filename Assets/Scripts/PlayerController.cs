using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [SerializeField] private bool run;
    [SerializeField] private bool crouch;
    [SerializeField] private bool jump;
    [SerializeField] private float speed;
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayMovementAnimations(horizontal);
        MoveCharacter(horizontal);

    }

    private void MoveCharacter(float horizontal) // character movement
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimations(float horizontal)
    {
        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal<0)
        {
        scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale; // here transforming the scale with new scale value we got

        animator.SetBool("Run", run);//Run animation
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
