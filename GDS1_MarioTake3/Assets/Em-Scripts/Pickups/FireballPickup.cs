using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPickup : MonoBehaviour
{
    // Start is called before the first frame update
    MarioAbilityState abilityState;
    Score score;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        abilityState = FindObjectOfType<MarioAbilityState>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.tag == "Rat")
        {

            if (abilityState.GetMarioState() == "Regular" || abilityState.GetMarioState() == "Mushroom")
            {
                abilityState.SetMarioState("Fireball");
                abilityState.Fireball();
             //   anim.Play("RatPowerUpGrown");

            }
            score.SetScore(1000);
            Destroy(this.gameObject);
        }
    }
}