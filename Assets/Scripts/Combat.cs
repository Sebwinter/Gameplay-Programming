using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditorInternal;
using UnityEngine;


[RequireComponent(typeof(PlayerStats))]

public class Combat : MonoBehaviour
{
    PlayerStats myStats;
    
    
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;
    

    public event System.Action OnAttack;

    void Start()
    {
        myStats = GetComponent<PlayerStats>();
        
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }


        //Melee Attack.
    public void Attack(PlayerStats targetStats)
    {

        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoMeleeDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / myStats.attackSpeed.GetValue();
        }


    }


    
    IEnumerator DoMeleeDamage(PlayerStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        int damage = myStats.damage.GetValue();            
        stats.TakeDamage(damage);
    }

 
    
}
