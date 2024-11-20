using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsBerettaController : MonoBehaviour
{
    public float speed = 100f; 
    public float lifetime = 5f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; 
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(collision.gameObject); // ”ничтожаем цель
            Destroy(gameObject); // ”ничтожаем пулю
        }
    }
}