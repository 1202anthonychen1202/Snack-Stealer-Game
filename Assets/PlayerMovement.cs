using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    private int score = 0;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
                rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            LevelManager.instance.GameOver();
            gameObject.SetActive(false);
            score = 0;
        }
        if (collision.CompareTag("Snack"))
        {
            score++;
        }
        if (collision.CompareTag("WinPlatform") && score >= 23)
        {
            LevelManager.instance.GameWin();
            gameObject.SetActive(false);
            score = 0;
        }

    }
}
