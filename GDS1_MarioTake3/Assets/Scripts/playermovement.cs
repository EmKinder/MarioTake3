using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public Rigidbody2D rigidbody2D;
    public Animator anim;
    Camera camera;
    bool canMove;
    Rigidbody2D rb;
    public Vector3 movement;
    bool movingRight;
    bool movingLeft;
    bool notMoving;
    bool ratJumping;
    public MarioAbilityState abilityState;


    void Start()
    {
        canMove = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ratJumping = false;
    }

    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        if (movement.x > 0)
        {
            movingLeft = false;
            movingRight = true;
            notMoving = false;
        }
        else if (movement.x < 0)
        {
            movingLeft = true;
            movingRight = false;
            notMoving = false;
        }
        else if (movement.x == 0)
        {
            notMoving = true;
            movingRight = false;
            movingLeft = false;
        }
        movement = Vector3.ClampMagnitude(new Vector3(movement.x, 0.0f, 0.0f), 1.0f);
    }

    void BeePosition()
    {
        transform.Translate(movement * Time.deltaTime * 10.0f, Space.World);
        if (movingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (movingLeft)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else if (notMoving)
        {
            transform.localRotation = transform.localRotation;
        }


    }

    void Update()
    {
        if (canMove)
        {
            GetMovementInput();
            BeePosition();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 10f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            ratJumping = true;
            if (movingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RatJump());
            }
            else if (movingLeft)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                StartCoroutine(RatJump());
            }
            else
            {
                anim.Play("RatJump");
            }

            
            
        }
        if (movingLeft || movingRight && !ratJumping)
        {
            anim.enabled = true;
            if(abilityState.GetMarioState() == "Regular")
            {
                anim.Play("RatRight");
            }
            else if(abilityState.GetMarioState() == "Mushroom")
            {
                anim.Play("RatGrownRight");
            }
            else if(abilityState.GetMarioState() == "Fireball")
            {
                anim.Play("RATPowerUpGrown");
            }
           
        }
        else if (notMoving)
        {
            anim.enabled = false;
        }
    }
    IEnumerator RatJump()
    {
        anim.enabled = true;
        if(abilityState.GetMarioState() == "Mushroom" || abilityState.GetMarioState() == "Fireball")
        {
            anim.Play("RatGrownJump");
        }
        else { 
        anim.Play("RatJump");
        }
        yield return new WaitForSeconds(2f);
        ratJumping = false;
    }
}

    // Start is called before the first frame update
/* void Start()
 {
     rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
     anim = this.gameObject.GetComponent<Animator>();
     camera = this.gameObject.GetComponentInChildren<Camera>();
 }

 // Update is called once per frame
 void Update()
 {
     if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(Vector2.right *moveSpeed *Time.deltaTime);
         // this.gameObject.transform.Rotate(0.0f, 0.0f, 0.0f);

         anim.Play("RatRight");
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(Vector2.left *moveSpeed *Time.deltaTime);
         anim.Play("RatLeft");
       //  this.gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);

     }
     if (Input.GetKeyDown(KeyCode.UpArrow)){
         float jumpVelocity = 10f;
         rigidbody2D.velocity = Vector2.up * jumpVelocity;
     }

 }

 IEnumerator RatJump()
 {
     anim.enabled = true;
     anim.Play("RatJump");
     yield return new WaitForSeconds(1);
     anim.enabled = false;
 }
}*/
