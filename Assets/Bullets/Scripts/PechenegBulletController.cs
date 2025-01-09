using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PechenegBulletController : MonoBehaviour
{
    private Rigidbody2D _bulletRigidBody;

    private float speed = 65f;

    void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
        _bulletRigidBody.velocity = transform.right * speed;
    }

    private void Update()
    {
        DeleteBulletOutOfGameField();
    }

    private void DeleteBulletOutOfGameField()
    {
        if (transform.position.x > 75 || transform.position.x < -75)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 75 || transform.position.y < -75)
        {
            Destroy(gameObject);
        }
    }
}
