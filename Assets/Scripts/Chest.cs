using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

   

    public override void Interact()
    {
        base.Interact();

        Open();
    }

    void Open()
    {

        Debug.Log("chest was opened");
        
    }


}
