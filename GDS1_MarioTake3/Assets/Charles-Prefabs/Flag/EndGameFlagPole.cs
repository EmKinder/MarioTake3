using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameFlagPole : MonoBehaviour
{

    public Animator flagAnim;
    public GameObject door;
    public GameObject flag;
    public AudioSource audio;
    public AudioClip levelComplete;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        audio = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rat")
        {
            Debug.Log("Hit");
            score.SetScore(5000);
            StartCoroutine(FlagMovement());
        }
    }

   
   IEnumerator FlagMovement()
    {
        flagAnim.SetTrigger("flagDown");
        audio.clip = levelComplete;
        audio.Play();
        yield return new WaitForSeconds(3f);
        door.SetActive(true);
        flag.SetActive(true);
    }
}
