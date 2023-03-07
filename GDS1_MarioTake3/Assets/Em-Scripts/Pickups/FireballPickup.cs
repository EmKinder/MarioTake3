using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPickup : MonoBehaviour
{
    // Start is called before the first frame update
    MarioAbilityState abilityState;
    Score score;
    ShootFireball shootFireball;
    // Start is called before the first frame update
    void Start()
    {
        shootFireball = GetComponent<ShootFireball>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (abilityState.GetMarioState() == "Regular" || abilityState.GetMarioState() == "Mushroom")
            {
                abilityState.SetMarioState("Fireball");
                shootFireball.enabled = true;
               
            }
            score.SetScore(1000);
        }
    }
}