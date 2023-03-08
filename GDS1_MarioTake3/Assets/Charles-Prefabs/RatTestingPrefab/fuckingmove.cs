using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckingmove : MonoBehaviour
{
    public float mov = 5;
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-(mov * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(mov * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            float jumpVelocity = 10f;
            rig.velocity = Vector2.up * jumpVelocity;
        }
    }
}
