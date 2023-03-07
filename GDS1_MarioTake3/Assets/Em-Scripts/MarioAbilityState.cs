using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAbilityState : MonoBehaviour
{
    string CurrentMarioState;

    // Start is called before the first frame update
    void Start()
    {
        CurrentMarioState = "Regular";
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
