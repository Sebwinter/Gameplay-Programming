using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrap : Gun
{
    void Update()
    {

        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(9, 9);

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("target stayed");
        SpellAttack(other);
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
