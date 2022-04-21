using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.UI;

public class HealthComp : MonoBehaviour
{
    private bool destroyed = false;
    [SerializeField] private int health = 1;

    void Start()
    {

    }

    void Update()
    {

    }


    public void ReceiveDamage(int damage)
    {
        if (health - damage <= 0)
        {

            if (destroyed)
            {
                return;
            }
            destroyed = true;

            Rigidbody2D objectBody = gameObject.GetComponent<Rigidbody2D>();
            if (objectBody)
            {
                objectBody.velocity = new Vector2(0f, 0f);
                objectBody.simulated = false;
            }

            Collider2D objectCollider = gameObject.GetComponent<Collider2D>();
            if (objectCollider)
            {
                objectCollider.enabled = false;
            }

            AIPath objectPath = gameObject.GetComponent<AIPath>();
            if (objectPath)
            {
                objectPath.enabled = false;
            }


            Animator objectAnimator = gameObject.GetComponent<Animator>();
            if (objectAnimator)
            {
                objectAnimator.SetBool("isDestroyed", true);
                objectAnimator.SetBool("isDead", true);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            health -= damage;

        }

    }

}
