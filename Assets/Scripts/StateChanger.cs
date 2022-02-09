using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateChanger : MonoBehaviour
{

    private EnemyState currentState;
    public readonly NoDebuffState noDebuffState = new NoDebuffState();
    public readonly BurningState burningState = new BurningState();

    void Start()
    {
        
        TransitionToState(noDebuffState);
    }

 
    void Update()
    {
        currentState.Update(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        currentState.OnTriggerEnter(this);
    }

    public void TransitionToState(EnemyState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }




}
