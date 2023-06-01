using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 80f;

    // Start is called before the first frame update
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.rotation * Vector3.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Surface") || other.gameObject.CompareTag("Door"))
        {
            DestroyThis();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            DestroyThis();
            other.gameObject.GetComponent<PlayerStatus>().GetDamage();
        }
    }
}
