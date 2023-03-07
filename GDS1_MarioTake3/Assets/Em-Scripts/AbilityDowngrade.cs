using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDowngrade : MonoBehaviour
{
    MarioAbilityState abilityState;
    public Lives lives;
    // Start is called before the first frame update
    void Start()
    {
        abilityState = GetComponent<MarioAbilityState>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DowngradeAbility()
    {
        if(abilityState.GetMarioState() == "Mushroom")
        {
            abilityState.SetMarioState("Regular");
        }

        if(abilityState.GetMarioState() == "Fireball")
        {
            abilityState.SetMarioState("Mushroom");
        }
        if(abilityState.GetMarioState() == "Regular")
        {
            lives.PlayerDeath();
        }
    }
}
