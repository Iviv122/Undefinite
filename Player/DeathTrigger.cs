using NaughtyAttributes;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    [SerializeField, Tag] string KillTag;
    [SerializeField] GameObject DeathEffect; 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == KillTag)
        {
            Die();
        }
    }
    public void Die()
    {

        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
