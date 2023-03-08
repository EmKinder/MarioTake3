using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot = true;
    bool scriptEnabled;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float cooldown = 1f;
    public MarioAbilityState abilityState;


    void Start()
    {
        scriptEnabled = false;
        abilityState = this.gameObject.GetComponent<MarioAbilityState>();
    }

    void Update()
    {
        if(abilityState.GetMarioState() == "Fireball")
        {
            scriptEnabled = true;
        }
        else
        {
            scriptEnabled = false;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space)) && canShoot && scriptEnabled)
        {
            GameObject go = (GameObject) Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
        }
    }

        IEnumerator CanShoot()
        {
            canShoot = false;
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
}
