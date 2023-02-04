/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damageAmount = 10; // The amount of damage to deal

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided with us has a Health script
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Deal damage to the player
            health.TakeDamage(damageAmount);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damageAmount = 10; // The amount of damage to deal

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided with us is not a wall or ground layer
        if (collision.gameObject.tag != "Wall" && collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            // Check if the object that collided with us has a Health script
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                // Deal damage to the player
                health.TakeDamage(damageAmount);
            }
        }
        else
        {
            // Destroy the object that collided with wall or ground layer
            Destroy(gameObject);
        }
    }
}