using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float Speed;
    public float jumpForce;

    private Vector3 characterScale;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Controle de Pulo")]
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private int extraJumps;
    public int extraJumpsValue = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        characterScale = transform.localScale;
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput.x * Speed, rb.linearVelocity.y);

        if (moveInput.x > 0)
        {
            transform.localScale = characterScale;
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-characterScale.x, characterScale.y, characterScale.z);
        }

        if (isGrounded)
        {
            anim.SetBool("jump", false);
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
        bool isMoving = moveInput.x != 0;
        anim.SetBool("walk", isMoving);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (isGrounded)
            {
                PerformJump();
            }
            else if (extraJumps > 0)
            {
                PerformJump();
                extraJumps--;
            }
        }
    }

    void PerformJump()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.jump);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("jump", true);
    }
}
