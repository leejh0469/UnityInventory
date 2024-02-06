using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    public ItemData itemData;
    public bool isSelled;
}

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _slotsParent;

    private SlotUI[] slots;

    private ShopItem[] shopItems;

    private int selecetedSlotIndex;
    private ShopItem selectedSlotItem;

    public ItemData[] item;

    [SerializeField] private GameObject _shop;
    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private PlayerStat _playerStat;


    private void Awake()
    {
        slots = _slotsParent.GetComponentsInChildren<SlotUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shopItems = new ShopItem[slots.Length];

        for(int i = 0; i < slots.Length; i++)
        {
            shopItems[i] = new ShopItem();
            slots[i].SetIndex(i);
            slots[i].Clear();
            slots[i].OnButtonClickAction += SelectItem;
        }

        for (int i = 0; i < item.Length; i++)
        {
            shopItems[i].itemData = item[i];
            shopItems[i].isSelled = false;
            slots[i].UpdateSlot(item[i]);
        }

        _shop.SetActive(false);
    }

    public void SelectItem(int index)
    {
        selecetedSlotIndex = index;
        selectedSlotItem = shopItems[selecetedSlotIndex];

        if (!HasItem(selecetedSlotIndex))
            return;

        _shopUI.UpdateSellInfoUI(selectedSlotItem);
    }

    private bool HasItem(int index)
    {
        return shopItems[index].itemData != null;
    }

    private void OnSlotButtonClick(int index)
    {
        SelectItem(index);
    }

    public void Buy()
    {
        if(_playerStat.Gold >= selectedSlotItem.itemData.price)
        {
            _playerStat.SubtractGoldValue(selectedSlotItem.itemData.price);
            Inventory.instance.AddItem(selectedSlotItem.itemData);

            selectedSlotItem.isSelled = true;
            _shopUI.UpdateSellInfoUI(selectedSlotItem);
        }
    }
}
