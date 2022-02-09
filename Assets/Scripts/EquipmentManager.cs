using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    Equipment[] currentEquip;
    Inventory inventory;

    public delegate void OnEquipChanged(Equipment newItem, Equipment oldItem);
    public OnEquipChanged onEquip;

    private void Start()
    {
        inventory = Inventory.instance;
        int numslots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquip = new Equipment[numslots];

    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquip[slotIndex] !=null)
        {
            oldItem = currentEquip[slotIndex];
            inventory.Add(oldItem);


        }

        if(onEquip != null )
        {
            onEquip.Invoke(newItem, oldItem);
        }
        currentEquip[slotIndex] = newItem;

    }

    public void Unequip (int slotIndex)
    {
        if(currentEquip[slotIndex] !=null)
        {
            Equipment oldItem = currentEquip[slotIndex];
            inventory.Add(oldItem);

            if (onEquip != null)
            {
                onEquip.Invoke(null, oldItem);
            }

            currentEquip[slotIndex] = null;

        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquip.Length; i ++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
