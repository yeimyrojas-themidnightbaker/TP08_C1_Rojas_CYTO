using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerHealing playerHealing;
    [SerializeField] private PlayerPowerUps playerPowerUps;
    [SerializeField] private GameManager gameManager;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float knockBackTimer;
    private int jumpCount;
    private bool jumpRequested;
    private bool jumpCutRequested;

    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    private float facingDirection = 1f;
    public float FacingDirection => facingDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerHealth.OnTakeDamage += HandleKnockBack;
        playerHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        playerHealth.OnTakeDamage -= HandleKnockBack;
        playerHealth.OnDied -= HandleDied;
    }

    private void Update()
    {
        if (gameManager.IsPaused)
            return;
        horizontalInput = 0f;
        if (AnyKeyHeld(playerData.LeftKeys))
        {
            horizontalInput -= 1f;
        }

        if (AnyKeyHeld(playerData.RightKeys))
        {
            horizontalInput += 1f;
        }

        if (AnyKeyDown(playerData.JumpKeys))
        {
            jumpRequested = true;
        }

        if (AnyKeyUp(playerData.JumpKeys))
        {
            jumpCutRequested = true;
        }

        if (horizontalInput != 0f)
        {
            facingDirection = horizontalInput;
            spriteRenderer.flipX = facingDirection < 0f;
        }

        if (knockBackTimer > 0f)
        {
            knockBackTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        Move();
        Jump();
        CutJump();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerData.GroundCheckRadius, groundLayer) != null;

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            jumpCount = 0;
        }
        else if (!isGrounded && jumpCount == 0)
        {
            jumpCount = 1;
        }
    }

    private void Move()
    {
        if (knockBackTimer > 0)
            return;
        if(playerHealing.IsHealing)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }
        rb.linearVelocity = new Vector2(horizontalInput * playerData.MoveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (jumpRequested && jumpCount < GetMaxJumps())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * playerData.JumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
        jumpRequested = false;
    }

    private void CutJump()
    {
        if (jumpCutRequested && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * playerData.JumpCutMultiplier);
        }
        jumpCutRequested = false;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null || playerData == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, playerData.GroundCheckRadius);
    }

    private void HandleKnockBack(float direction)
    {
        rb.linearVelocity = new Vector2(playerData.KnockBackForce.x * direction, playerData.KnockBackForce.y);
        knockBackTimer = playerData.KnockBackDuration;
    }

    private void HandleDied()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
        enabled = false;
    }

    private int GetMaxJumps()
    {
        if (playerPowerUps.HasExtraJump)
            return playerData.MaxJumps + playerData.ExtraJumps;
        return playerData.MaxJumps;
    }
    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
                return true;
        }
        return false;
    }

    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
                return true;
        }
        return false;
    }

    private bool AnyKeyUp(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyUp(key))
                return true;
        }
        return false;
    }
}
