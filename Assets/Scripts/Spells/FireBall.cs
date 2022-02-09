using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public class FireBall : Gun
{

    void Update()
    {

        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(9, 9);

    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] tmp = Physics.OverlapSphere(other.transform.position, range, layerMask);

     
        foreach (Collider collider in tmp)
        {
            //SpellAttack(other);
            PlayerStats health = collider.GetComponent<PlayerStats>();
            int spellDamage = stats.spellDamage.GetValue();

            if (health != null)
            {
                health.TakeDamage(spellDamage);
            }

        }

        Destroy(spell);
    }
}


