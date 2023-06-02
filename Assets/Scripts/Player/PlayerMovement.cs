using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private Transform groundSensor;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator playerAnimator;
    private Rigidbody2D rb;

    private float horizontalDirection, verticalDirection;
    private float gravityScale = 3;
    private bool isAlive = true;
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isClimbing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && isOnGround())
                playerAnimator.Play("Idle");
            if (isOnGround())
            {
                if (isJumping)
                {
                    isJumping = false;
                    playerAnimator.Play("Landing");
                }
            }
            horizontalDirection = Input.GetAxisRaw("Horizontal");
            playerAnimator.SetBool("Is Walking", horizontalDirection != 0);
            Flip();
            if (Input.GetButtonDown("Jump") && isOnGround())
            {
                isJumping = true;
                playerAnimator.Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
            if (isClimbing)
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
            else
                rb.velocity = new Vector2(horizontalDirection * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }

    private void Flip()
    {
        if (Input.mousePosition.x < Screen.width / 2)
            if (isFacingRight)
            {
                isFacingRight = false;
                gameObject.transform.Rotate(0, 180, 0);
            }
        
        if (Input.mousePosition.x >= Screen.width / 2)
            if (!isFacingRight)
            {
                isFacingRight = true;
                gameObject.transform.Rotate(0, 180, 0);
            }
    }

    private bool isOnGround()
    {
        return Physics2D.OverlapBox(groundSensor.position, new(0.4f, 0.02f), 0, groundLayer);
    }

    public void Die()
    {
        isAlive = false;
        playerAnimator.Play("Dying");
    }

    public void Destroy() => Destroy(gameObject);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isAlive && other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isAlive && other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = gravityScale;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isAlive && other.CompareTag("Exit") && Input.GetKey(KeyCode.E))
            animator.Play("Level Fade In");
    }
}
