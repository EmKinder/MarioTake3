using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{

    public GameObject doorOpen;
    LoadScene loadScene;
    // Start is called before the first frame update
    void Start()
    {
        loadScene = FindObjectOfType<LoadScene>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rat")
        {
            doorOpen.SetActive(true);
            loadScene.LoadMainMenu();
        }
    }
}
