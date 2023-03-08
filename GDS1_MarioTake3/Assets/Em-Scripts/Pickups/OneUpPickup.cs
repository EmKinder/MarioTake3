using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpPickup : MonoBehaviour
{

    Lives lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = FindObjectOfType<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("One up");
            lives.AddLife();
            Destroy(this.gameObject);
        }
    }
}
