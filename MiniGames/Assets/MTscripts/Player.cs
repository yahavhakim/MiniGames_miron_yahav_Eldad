using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber; // Указывает на номер игрока: 1 или 2
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float kickForce = 10f; // Сила удара по мячу

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float move = 0f;

        // Определение клавиш для движения и прыжка в зависимости от номера игрока
        if (playerNumber == 1)
        {
            move = Input.GetAxis("Player1_Horizontal");
            if (isGrounded && Input.GetButtonDown("Player1_Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (Input.GetButtonDown("Player1_Kick"))
            {
                KickBall();
            }
        }
        else if (playerNumber == 2)
        {
            move = Input.GetAxis("Player2_Horizontal");
            if (isGrounded && Input.GetButtonDown("Player2_Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (Input.GetButtonDown("Player2_Kick"))
            {
                KickBall();
            }
        }

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Другой код для мяча и ворот
    }

    void KickBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball != null)
        {
            Vector2 kickDirection = (ball.transform.position - transform.position).normalized;
            ball.GetComponent<Rigidbody2D>().velocity = kickDirection * kickForce;
        }
    }
}
