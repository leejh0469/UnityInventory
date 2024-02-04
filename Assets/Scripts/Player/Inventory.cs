using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Item
{
    public ItemData itemData;
    public bool equip;
}

public class Inventory : MonoBehaviour
{
    private Item[] items;

    [SerializeField] private GameObject slotsParent;
    private SlotUI[] slots;

    [SerializeField] private GameObject equipPopupUI;
    [SerializeField] private GameObject unEquipPopupUI;

    private int selecetedSlotIndex;
    private Item selectedSlotItem;

    private void Awake()
    {
        slots = slotsParent.GetComponentsInChildren<SlotUI>();
    }

    private void Start()
    {
        items = new Item[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            items[i] = new Item();
            slots[i].SetIndex(i);
            slots[i].Clear();
        }
    }

    public void UpdateSlot(int index)
    {
        slots[index].UpdateSlot(items[index]);
    }

    public void SelectItem(int index)
    {
        selecetedSlotIndex = index;
        selectedSlotItem = items[selecetedSlotIndex];

        if(selectedSlotItem.equip)
            equipPopupUI.SetActive(true);
        else
            unEquipPopupUI.SetActive(true);
    }

    public void AddItem(ItemData item)
    {
        int index = FindEmptySlot();
        if(index == -1)
        {
            return;
        }

        items[index].itemData = item;
        items[index].equip = false;

        UpdateSlot(index);
    }

    private int FindEmptySlot()
    {
        for (int i = 0;i < items.Length;i++)
        {
            if (items[i].itemData == null)
            {
                return i;
            }
        }

        return -1;
    }
}
