
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;
    public Transform playerP;
    public GameObject itemDropped;
    public Item itemList;
    //int instanceNumber = 1;

    
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }

    public void OnRemoveButton()
    {
        //dropItem();

        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item !=null)
        {
            item.Use();
        }
    }

    //public void dropItem()
    //{

    //    int currentSpawnPointIndex = 0;
    //    GameObject currentItem = Instantiate(itemDropped, itemList.spawnPoint[currentSpawnPointIndex], Quaternion.identity);
    //    currentItem.name = item.name + instanceNumber;


    //}


}
