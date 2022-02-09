using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : PlayerStats
{
    

    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquip += OnEquip;

        

    }

    void OnEquip(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armour.AddMod(newItem.armourMod);
            damage.AddMod(newItem.damageMod);
            attackSpeed.AddMod(newItem.attackSpeedMod);
            spellDamage.AddMod(newItem.spellDamageMod);
            range.AddMod(newItem.rangeMod);
        }

        if(oldItem !=null)
        {
            armour.RemoveMod(oldItem.armourMod);
            damage.RemoveMod(oldItem.damageMod);
            attackSpeed.RemoveMod(newItem.attackSpeedMod);
            spellDamage.RemoveMod(newItem.spellDamageMod);
            range.AddMod(newItem.rangeMod);
        }
    }

    public override void Die()
    {
        base.Die();//kills player, plays death screen.
        
        PlayerManager.instance.KillPlayer();
    }

}
