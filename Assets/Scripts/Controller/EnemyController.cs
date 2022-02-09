using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Combat combat;
    public float spellchain;

    //private EnemyState currentState;
    //public readonly NoDebuffState noDebuffState = new NoDebuffState();
    //public readonly BurningState burningState = new BurningState();
    //public readonly ChillingState chillingState = new ChillingState();
    //public readonly SlowedState slowedState = new SlowedState();
    //public readonly StunnedState StunnedState = new StunnedState();

    // Start is called before the first frame update
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<Combat>();
        //TransitionToState(noDebuffState);
    }

    private void Update()
    {
        //currentState.Update(this);
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats !=null)
                {
                    combat.Attack(targetStats); //attack the target
                }
 
                FaceTarget(); //faces the target

            }
        }
   
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    currentState.OnCollisionEnter(this);
    //}

    //public void TransitionToState(EnemyState state)
    //{
    //    currentState = state;
    //    currentState.EnterState(this);
    //}

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spellchain);
    }

}
