using UnityEngine;

public abstract class EnemyState
{
    public abstract void EnterState(StateChanger enemy);

    public abstract void Update(StateChanger enemy);

    public abstract void OnTriggerEnter(StateChanger enemy);

}
