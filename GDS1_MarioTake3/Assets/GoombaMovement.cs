using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Renderer rend;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
        {
            enemy.velocity = -Vector2.right * enemySpeed;
        }
    }
}
