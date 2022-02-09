using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BurningState : EnemyState 
{
    private WaitForSeconds dotTimer = new WaitForSeconds(2.0f);
    private MonoBehaviour mB;

    public override void EnterState(StateChanger enemy)
    {
        //StartCoroutine();
        Debug.Log(this);
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine();
        }
            
        enemy.TransitionToState(enemy.noDebuffState);
    }

    public override void OnTriggerEnter(StateChanger enemy)
    {
        Debug.Log(this);
   
    }
    public override void Update(StateChanger enemy)
    {
    
    }


    public void StartCoroutine()
    {        
        mB = GameObject.FindObjectOfType<MonoBehaviour>();        
        mB.StartCoroutine(DotTimer(DotDamage,1,3));
    
    }

    private void DotDamage()
    {
        //Debug.Log("burningingna;kajf");
    }


    public IEnumerator DotTimer(Action method, float interval, float BurnDuration)
    {
        for (int i = 0; i < BurnDuration; i++)
        {
            method();
            yield return new WaitForSeconds(interval);
            //method();
        }
        
             
        
    }
}
