using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        new WaitForSeconds(5);
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = transform.Find("itemSlotContainer/itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        Debug.Log(inventory.GetItemList().Count);
        int x = 0;
        int y = 1;
        float itemSlotCellSize = 60f;
        //itemSlotTemplate.gameObject.SetActive(true);
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotTemplate).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
        //itemSlotTemplate.gameObject.SetActive(false);
    }
}
