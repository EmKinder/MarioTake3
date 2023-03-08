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
        abilityState = FindObjectOfType<MarioAbilityState>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(2.0f * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(abilityState.GetMarioState() == "Regular") {
                abilityState.SetMarioState("Mushroom");
                abilityState.Mushroom();

            }
            score.SetScore(1000);
            Destroy(this.gameObject);
        }

    }
}
