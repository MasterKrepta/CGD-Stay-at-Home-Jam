using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunOnTrigger : MonoBehaviour
{
    public LayerMask hitLayer;

    private void OnTriggerEnter(Collider other)
    {
        var em = other.GetComponent<EnemyMovement>();
        if (em != null && em.IsStunned == false)
        {
            em.StunEnemy();
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }


}
