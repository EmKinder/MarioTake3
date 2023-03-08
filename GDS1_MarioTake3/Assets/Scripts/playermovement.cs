using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right *moveSpeed *Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left *moveSpeed *Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            float jumpVelocity = 7f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
    }
}
