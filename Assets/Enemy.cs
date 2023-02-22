using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DetectionZone detectionZone;
    public Animator animator;

    public float moveSpeed = 3f;

    Rigidbody2D rb;

    public int count = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            count++;
            if (count > 400)
            {
                count = 0;
            }
            Vector2 direction;
            if (count < 100)
            {
                direction.x = 1;
                direction.y = 0;
            }
            else if (count >= 100 && count < 200)
            {
                direction.x = 0;
                direction.y = 1;
            }
            else if (count >= 200 && count < 300)
            {
                direction.x = -1;
                direction.y = 0;
            }
            else
            {
                direction.x = 0;
                direction.y = -1;
            }
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }

    }
    
}
