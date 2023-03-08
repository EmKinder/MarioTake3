using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 velocity;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(velocity.x, -velocity.y);

        if(collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            score.SetScore(100);
            Explode();
            
        }
        if(collision.contacts[0].normal.x != 0 && collision.collider.tag != "Player" && collision.collider.tag != "Fireball")
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(this.gameObject);
    }
}
