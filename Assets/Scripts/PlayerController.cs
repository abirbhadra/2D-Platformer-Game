using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;

    [SerializeField] private bool run;
    [SerializeField] private bool crouch;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private bool isGrounded = false;

   

    [SerializeField] public bool IsShiftPressed;
    [SerializeField] public float destroyThreshold = -8f;

    public void KillPlayer()
    {
        PlayerHealthManager.health--;
        if(PlayerHealthManager.health <=0)
        {
            Debug.Log("Player got killed");
            StartCoroutine(ReloadSceneAfterDelay(0.55f));
        }     

    }

    public ScoreController scoreController;
    public void PickupKey()
    {
        Debug.Log("Player Picked up KEY");
        scoreController.IncreaseScore(10);
    }
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player Grounded");
        }

    }
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayMovementAnimations(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        IsShiftPressed = Input.GetKey(KeyCode.LeftShift);

        PlayerDeath();
    }

    private void PlayerDeath()
    {
        if (transform.position.y <= destroyThreshold)
        {
            
                StartCoroutine(ReloadSceneAfterDelay(0.5f)); // Start the coroutine with a 0.5-second delay
            
        }
    }
    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        // Set "Death" to true, triggering the death animation
        animator.SetBool("Death", true);

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the scene after the delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void MoveCharacter(float horizontal, float vertical) // character movement
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0 && isGrounded && IsShiftPressed )
        {
            isGrounded = false;
            Debug.Log(" Player is Jump");
            rb2d.AddForce(new Vector2(0f, 2f *jump), ForceMode2D.Impulse);   
        }
        else if(vertical > 0 && isGrounded)
        {
            isGrounded = false;
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    private void PlayMovementAnimations(float horizontal, float vertical)
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
        if (IsShiftPressed)
        {
            run = true;
        }
        else
        {
            run = false;
        }

        animator.SetBool("Crouch", crouch);//Crouch Animation
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch = true;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            crouch = false;

        /* animator.SetBool("Jump", jump);//jump Animation
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        if (Input.GetKeyUp(KeyCode.Space))
            jump = false; */

        if(vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }



}
