using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAbilityState : MonoBehaviour
{
    public string CurrentMarioState;
    public ShootFireball shootFireball;
    public Lives lives;
    Animator anim;
    public AudioSource audio;
    public AudioClip collideWithEnemy;
    public AudioClip death;
    GameObject audioSourceGO;
    public playermovement playermovement;
    bool canBeHit; 

   

    // Start is called before the first frame updated
    void Start()
    {
        CurrentMarioState = "Regular";
        anim = gameObject.GetComponent<Animator>();
        lives = FindObjectOfType<Lives>();
        canBeHit = true;


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -40.0f)
        {
            StartCoroutine(PlayerDeath());
        }
    }

    public void SetMarioState(string state)
    {
        CurrentMarioState = state;
        //Regular, Mushroom, Fireball, Star
    }

    public string GetMarioState()
    {
        return CurrentMarioState;
    }

    public void DowngradeAbility()
    {
        if (GetMarioState() == "Mushroom")
        {
            SetMarioState("Regular");
            audio.clip = collideWithEnemy;
            DowngradeToMushroom();
            audio.Play();
        }

        else if (GetMarioState() == "Fireball")
        {
            audio.clip = collideWithEnemy;
            audio.Play();
            DowngradeToMushroom();
            SetMarioState("Mushroom");
        }
        else if(GetMarioState() == "Regular")
        {

            StartCoroutine(PlayerDeath());
            
        }
    }

    public void Mushroom()
    {

        StartCoroutine(MushroomGrow());
    }

    IEnumerator MushroomGrow()
    {
        canBeHit = false;
        anim.Play("RatGrow");
        playermovement.CanMove(false);
        yield return new WaitForSeconds(1);
            playermovement.CanMove(true);
        canBeHit = true;
    }

    public void Fireball()
    {
        StartCoroutine(FireballGrow());
     //   transform.localScale = (new Vector3(2.0f, 2.0f, 2.0f));


    }

    IEnumerator FireballGrow()
    {
        canBeHit = false;
        anim.Play("RATPowerUpGrown");
        playermovement.CanMove(false);
        yield return new WaitForSeconds(1);
        playermovement.CanMove(true);
        canBeHit = true;
    }

    public void DowngradeToMushroom()
    {
        anim.Play("RatGrow");
        StartCoroutine(Invincibility());
    }

    public void DowngradeToRegular()
    {
        anim.Play("RatShrink");
        StartCoroutine(Invincibility());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy" && canBeHit)
        {
            if (CurrentMarioState == "Star")
            {
                Debug.Log("Enemy Killed");
               // anim.Play()
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Mario Killed");
                DowngradeAbility();
               
            }
        }
    }



    IEnumerator PlayerDeath()
    {
        audio.clip = death;
        audio.Play();
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1.3f);
        lives.PlayerDeath();
    }

    IEnumerator Invincibility()
    {
        canBeHit = false;
        yield return new WaitForSeconds(3.0f);
        canBeHit = true;
    }


}
    
