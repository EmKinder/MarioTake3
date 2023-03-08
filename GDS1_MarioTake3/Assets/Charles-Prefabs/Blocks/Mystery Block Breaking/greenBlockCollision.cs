using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBlockCollision : MonoBehaviour
{
    public Animator blockAnimation;
    public GameObject fuckingGame;
    public GameObject fireball;
    public GameObject mushroom;
    Transform blockPosition;
    public MarioAbilityState abilityState;

    // Start is called before the first frame update
    void Start()
    {
        abilityState = FindObjectOfType<MarioAbilityState>();
    }

    // Update is called once per frame
    void Update()
    {
        if((abilityState.GetMarioState() == "Mushroom" || abilityState.GetMarioState() == "Fireball") && (this.gameObject.tag == "MushroomBlock" || this.gameObject.tag == "FireballBlock"))
        {
            this.gameObject.tag = "FireballBlock";
        }
        else if(abilityState.GetMarioState() == "Regular" && (this.gameObject.tag == "MushroomBlock" || this.gameObject.tag == "FireballBlock"))
        {
            this.gameObject.tag = "MushroomBlock";

        }

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
        if(this.gameObject.tag == "FireballBlock") {
            Debug.Log("Fireball Triggered");
            Instantiate(fireball, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
        }
        else if (this.gameObject.tag == "MushroomBlock")
        {
            Debug.Log("Mushroom Triggered");
            Instantiate(mushroom, new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z), Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}
