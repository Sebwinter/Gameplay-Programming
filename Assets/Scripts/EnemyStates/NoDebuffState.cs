using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDebuffState : EnemyState
{
    public override void EnterState(StateChanger enemy)
    {
        //Debug.Log(this);
    }

    public override void OnTriggerEnter(StateChanger enemy)
    {
        enemy.TransitionToState(enemy.burningState);
   
    }

   
    public override void Update(StateChanger enemy)
    {
        

    }
}
