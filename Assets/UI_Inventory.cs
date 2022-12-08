using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = transform.Find("itemSlotTemplate");
        Debug.Log("UI_InventoryAwake");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        Debug.Log(inventory.GetItemList().Count);
        //Debug.Log("F");
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 50f;
        foreach (Item item in inventory.GetItemList())
        {
            Debug.Log("??????????????");
            //RectTransform itemSlotRectTransform = 
            Instantiate(itemSlotTemplate);//.GetComponent<RectTransform>();
            Debug.Log("*********");
            //itemSlotRectTransform.gameObject.SetActive(true);
            Debug.Log("----------");
            //itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            Debug.Log("!!!!!!!!!!!");
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
