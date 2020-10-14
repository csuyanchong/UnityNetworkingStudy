using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();

        if (hitPlayer!= null)
        {
            print("Hit!");
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(30);

            Destroy(gameObject);
            
        }
    }
}
