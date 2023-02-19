using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloc : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mur")
        {
            GameObject enemy = other.gameObject;
            Destroy(enemy);
        }
        Destroy(gameObject);
    }
}
