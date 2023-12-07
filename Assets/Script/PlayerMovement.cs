using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 400f;

    private bool isJumping;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Goal":
                SceneManager.LoadScene("Scene2");
                break;
            case "Goal2":
                SceneManager.LoadScene("Scene3");
                break;
            case "Goal3":
                SceneManager.LoadScene("WinScreen");
                break;
            case "Obstacle":
                GameOver();
                 SceneManager.LoadScene("GameOverScreen");
                break;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}