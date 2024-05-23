using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onPlayerHitted;

    private Rigidbody2D rb;
    private Animator animator;
    private bool canJump;
    private float forwardForce;
    private bool isEnabled;

    public float jumpFactor = 5f;
    public float forwardFactor = 0.2f;
    public Transform startPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        canJump = true;
        isEnabled = false;
    }

    public void SetActive()
    {
        isEnabled = true;
        canJump = true;
        animator.Play("player_running");
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.localPosition = startPlayerPosition.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
        }
    }

    void Jump()
    {
        if (!isEnabled) return;

        if(canJump)
        {
            canJump = false;
            if(transform.position.x < 0)
            {
                forwardForce = forwardFactor;
            }
            else
            {
                forwardForce = 0f;
            }

            rb.velocity = new Vector2(forwardForce, jumpFactor);
            animator.Play("player_jumping");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnabled) return;

        if (collision.gameObject.tag == "Obstacle")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.Play("player_hurt");
            isEnabled = false;
            onPlayerHitted.Invoke();
        } 
        else
        {
            animator.Play("player_running");
        }

        canJump = true;
    }
}
