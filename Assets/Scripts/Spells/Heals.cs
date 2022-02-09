using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : Gun
{
    void Update()
    {

        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(9, 9);
        
    }

 

}
