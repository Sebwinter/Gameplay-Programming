using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : Gun
{
    void Update()
    {

        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(9, 9);

    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] tmp = Physics.OverlapSphere(other.transform.position, range, layerMask);

        for (int i = 0; i < tmp.Length; i++)
        {       
            
            SpellAttack(other);
            
        }


        Destroy(spell);
    }

    private void SpellAttack(Collider collider)
    {
        PlayerStats health = collider.GetComponent<PlayerStats>();
        int spellDamage = stats.spellDamage.GetValue();

        if (health != null)
        {
            health.TakeDamage(spellDamage);
        }

    }
}
