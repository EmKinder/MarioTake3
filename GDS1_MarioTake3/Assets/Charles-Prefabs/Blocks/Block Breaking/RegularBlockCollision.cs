using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBlockCollision : MonoBehaviour
{

    public Animator blockAnimation;
    public float delay;
    public GameObject spriteSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rat")
        {
            Debug.Log("Collision Detected");
            Object.Destroy(spriteSquare);
            blockAnimation.SetTrigger("Blockbreaking");
            float animTime = blockAnimation.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animTime + delay);
        }
    }
}
