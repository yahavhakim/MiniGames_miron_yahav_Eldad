using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRplayer2 : MonoBehaviour
{
    public float speed = 5f;  // Adjust the speed as needed
    public float jumpForce = 10f;  // Adjust the jump force as needed
    private bool isGrounded;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal_Player2");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Assuming there is a GameObject with the tag "Ground" for detecting ground
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}