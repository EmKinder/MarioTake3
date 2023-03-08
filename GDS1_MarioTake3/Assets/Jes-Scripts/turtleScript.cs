using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleScript : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Renderer rend;
    public float enemySpeed;
    public Animator animationControl;
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

            animationControl.SetTrigger("TurtleRight");
            enemy.velocity = gameObject.transform.right * enemySpeed;



        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe-Regular")
        {
            animationControl.SetTrigger("TurtleLeft");
            enemy.transform.Rotate(0f, 180f, 0);
            


        }
        if (collision.gameObject.tag == "Pipe-Regular")
        {
            animationControl.SetTrigger("TurtleRight");
            enemy.transform.Rotate(0f, 180f, 0);

        }

        if (collision.gameObject.tag == "Player")
        {
            animationControl.SetTrigger("TurtleDeath");
            enemy.transform.Rotate(0f, 180f, 0);


        }



    }
}
