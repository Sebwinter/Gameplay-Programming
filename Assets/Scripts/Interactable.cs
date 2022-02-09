
using NUnit.Framework;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTrasform;  //used so items or chests can only be interacted in certain points. 
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;


    public virtual void Interact ()
    {
        //This is used to be overwritten, so it can be used by items, enemies and chests. 
        //Debug.Log("I am ALIVVVEEE.");

    }
    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTrasform.position);
            if(distance <= radius)
            {
                Interact();
                //Debug.Log("INTERACT"); --(For testing.)--
                hasInteracted = true;
            }
        }
    }

    public void Onfocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;

    }
    
    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if(interactionTrasform == null)
        {
            interactionTrasform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTrasform.position, radius);

    }
}
