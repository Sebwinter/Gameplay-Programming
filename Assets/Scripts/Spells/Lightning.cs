using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Lightning : Gun
{
    bool targetHit = false;
    private readonly List<Transform> targets = new List<Transform>();
    //private int targetIndex;



    void Update()
    { 

        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(9, 9);

    }
    
   

    //Detects when object is hit.
    private void OnTriggerEnter(Collider other)
    {

        if (!targetHit && other.tag == "Enemy")
        {
            targetHit = true;
            Collider[] tmp = Physics.OverlapSphere(other.transform.position, range, layerMask);
            if( tmp.Length > 0)
            {
                foreach (Collider collider in tmp)
                {
                    if (collider.transform != other.transform && collider.transform != transform)
                    {
                        targets.Add(collider.transform);

                    }
                }

            }
            


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

        //MyTarget = targets[targetIndex];
        //targetIndex++;


    }

    
}
