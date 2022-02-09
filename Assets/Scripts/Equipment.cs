using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public int armourMod;
    public int damageMod;
    public int attackSpeedMod;
    public int spellDamageMod;
    public int rangeMod;


    public override void Use()
    {
        base.Use();
        RemoveItem();
        EquipmentManager.instance.Equip(this);
        
    }

}

public enum EquipmentSlot { Head, Chest, Legs, OffHand, MainHand, Feet}