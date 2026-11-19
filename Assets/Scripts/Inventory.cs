using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory playerInventory { get; private set; }

    public List<string> itemGotten = new List<string>();

    private void Start()
    {
        if(playerInventory == null)
        {
            playerInventory = this;
        }
    }
    public void AddToInventory(string itemName)
    {
        itemGotten.Add(itemName);
    }
}
