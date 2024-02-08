using UnityEngine;

public class MRplayer : MonoBehaviour
{

    public float speed = 5f; // Скорость перемещения игрока

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем входные данные по горизонтали (влево <-1, вправо >1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Вычисляем вектор скорости
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        Vector2 moveVelocity = moveDirection * speed;

        // Применяем скорость к Rigidbody2D
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);
    }
}
