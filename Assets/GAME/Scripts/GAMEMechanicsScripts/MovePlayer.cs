using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 3.5f;

    [Header("Detección de Suelo (Raycast)")]
    [SerializeField] private float rayDistance = 0.2f; 
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("movement", Mathf.Abs(moveInput.x));

        if (moveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1, 1);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);


        isGrounded = hit.collider != null;

        
        animator.SetBool("enSuelo", isGrounded);

        
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, isGrounded ? Color.green : Color.red);
    }
}