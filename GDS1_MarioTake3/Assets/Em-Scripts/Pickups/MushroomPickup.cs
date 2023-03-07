using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickup : MonoBehaviour
{

    MarioAbilityState abilityState;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(abilityState.GetMarioState() == "Regular") {
                abilityState.SetMarioState("Mushroom");
                //change mario

            }
            score.SetScore(1000);  
        }

    }
}
