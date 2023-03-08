using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAbilityState : MonoBehaviour
{
    public string CurrentMarioState;
    public ShootFireball shootFireball;
    public Lives lives;
    Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentMarioState = "Regular";
        anim = gameObject.GetComponent<Animator>();
        lives = FindObjectOfType<Lives>();


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -40.0f)
        {
            lives.PlayerDeath();
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
        }

        else if (GetMarioState() == "Fireball")
        {
            SetMarioState("Mushroom");
        }
        else if(GetMarioState() == "Regular")
        {
            lives.PlayerDeath();
        }
    }

    public void Mushroom()
    {
        anim.Play("RatGrow");
        
    }

    public void Fireball()
    {
        anim.Play("RatPowerUp");
     //   transform.localScale = (new Vector3(2.0f, 2.0f, 2.0f));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy")
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

}
    
