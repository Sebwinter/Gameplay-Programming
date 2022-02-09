using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp ()
    {
        
        Debug.Log("Picked up the " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);  // add to inventory

        if(wasPickedUp)
        {
            Destroy(gameObject);

        }
        

    }

}
