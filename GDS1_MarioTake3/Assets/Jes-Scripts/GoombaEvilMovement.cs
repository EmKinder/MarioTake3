using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEvilMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public SpriteRenderer rend;
    public float enemySpeed;
    public Animator animationControl;
    public GameObject objection;
    public bool forward;
    public PolygonCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (rend.isVisible)
        {

            animationControl.SetTrigger("GULeft");
            enemy.velocity = -gameObject.transform.right * enemySpeed;



        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rend.isVisible)
        {
            if (collision.gameObject.tag == "Pipe-Regular")
            {
                animationControl.SetTrigger("GURight");
                enemy.transform.Rotate(0f, 180f, 0);

            }
            if (collision.gameObject.tag == "Pipe-Regular")
            {
                animationControl.SetTrigger("GULeft");
                enemy.transform.Rotate(0f, 180f, 0);
            }
            if (collision.gameObject.tag == "Player")
            {
                animationControl.SetTrigger("GUDeath");
                rend.enabled = !rend.enabled;
                col.enabled = !col.enabled;
                // enemy.transform.Rotate(0f, 180f, 0);

            }
        }
    }
    }
