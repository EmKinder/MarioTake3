using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBlockCollision : MonoBehaviour
{
    public Animator blockAnimation;
    public GameObject fuckingGame;

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
            StartCoroutine(MysteryBox());
        }
    }

    IEnumerator MysteryBox()
    {
        Debug.Log("Collision Detected");
        blockAnimation.SetTrigger("ifHit");
        yield return new WaitForSeconds(1);
        fuckingGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
