using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
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
            
               animationControl.SetTrigger("GoombaLeft");
                enemy.velocity = -gameObject.transform.right * enemySpeed;
           
                
            
        }
        

    }


   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rend.isVisible)
        {
            if (collision.gameObject.tag == "pip1")
            {
                animationControl.SetTrigger("GoombaRight");
                enemy.transform.Rotate(0f, 180f, 0);




            }
            if (collision.gameObject.tag == "pip-reg2")
            {
                animationControl.SetTrigger("GoombaLeft");
                enemy.transform.Rotate(0f, 180f, 0);
            }
            if (collision.gameObject.tag == "Player")
            {
                animationControl.SetTrigger("GoombaDeath");
                animationControl.SetTrigger("GoombaGone");
                rend.enabled = !rend.enabled;
                col.enabled = !col.enabled;
                // enemy.transform.Rotate(0f, 180f, 0);

            }
        }
       

    }
    
  
}
