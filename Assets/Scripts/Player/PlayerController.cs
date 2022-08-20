using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    float HorizontalInput;
    public float JumpForce;
    public float MovementSpeed;
    public float jumpDelay = 0.25f;
    
    float JumpTimer;

    [Header("Health")]
    public float Health;

    [Header("Gravity")]
    public float gravity;
    public float LinealDrag;
    public float fallMultiplier;

    public LayerMask Grounded;

    public Vector3 colliderOffSet;
    Rigidbody2D rigidBody2D;
    Animator animator;
    public static PlayerController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<LevelExit>().levelFinished == false)
        {
            rigidBody2D.velocity = new Vector2(HorizontalInput * MovementSpeed, rigidBody2D.velocity.y);
        }
        
        if (JumpTimer > Time.time)
        {
            Jump();
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if (Input.GetButtonUp("Jump") && rigidBody2D.velocity.y > 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y / 1.5f);
        }
    }
    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            JumpTimer = Time.time + jumpDelay;
        }
        GameManager.Instance.PlayerDeath();
        Flip();

        animator.SetBool("Run", HorizontalInput != 0);
        animator.SetBool("IsGrounded", IsGrounded());
    }
    void Flip()
    {
        if (HorizontalInput > 0.01)
        {
            transform.localScale = Vector2.one;
        }
        else if (HorizontalInput < -0.01)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    #region Jump Logic
    void Jump()
    {
        if (IsGrounded())
        {
            rigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            JumpTimer = 0;
        }
    }
    bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position + colliderOffSet, Vector2.down, 0.39f, Grounded) ||
            Physics2D.Raycast(transform.position - colliderOffSet, Vector2.down, 0.39f, Grounded))
        {
            return true;
        }
        else
        {
            rigidBody2D.gravityScale = gravity;
            rigidBody2D.drag = LinealDrag * 0.15f;
            if (rigidBody2D.velocity.y < 0)
            {
                rigidBody2D.gravityScale = gravity * fallMultiplier;
            }
            else if (rigidBody2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rigidBody2D.gravityScale = gravity * (fallMultiplier/2);
            }
            return false;
        }
    }
    #endregion
}
