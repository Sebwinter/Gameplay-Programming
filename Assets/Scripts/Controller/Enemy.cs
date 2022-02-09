using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    PlayerStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<PlayerStats>();

       
    }
    public override void Interact()
    {
        base.Interact();
        Combat playerCombat = playerManager.player.GetComponent<Combat>();
        if(playerCombat !=null)
        {
            playerCombat.Attack(myStats);
            
        }
    }

}
