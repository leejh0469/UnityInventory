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
    public static Inventory instance;

    private Item[] items;

    [SerializeField] private GameObject slotsParent;
    private SlotUI[] slots;

    [SerializeField] private GameObject equipPopupUI;
    [SerializeField] private GameObject unEquipPopupUI;
    [SerializeField] private GameObject usePopupUI;

    private int selecetedSlotIndex;
    private Item selectedSlotItem;

    public ItemData[] item;

    [SerializeField] private GameObject _inventoryUI;

    private PlayerEquip _playerEquip;
    private PlayerStat _playerStat;

    private void Awake()
    {
        slots = slotsParent.GetComponentsInChildren<SlotUI>();
        _playerEquip = GetComponent<PlayerEquip>();
        _playerStat = GetComponent<PlayerStat>();
        instance = this;
    }

    private void Start()
    {
        items = new Item[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            items[i] = new Item();
            slots[i].SetIndex(i);
            slots[i].Clear();
            slots[i].OnButtonClickAction += OnSlotButtonClick;
        }

        for (int i = 0;i < item.Length; i++)
        {
            AddItem(item[i]);
        }

        _inventoryUI.SetActive(false);
    }

    public void UpdateSlot(int index)
    {
        slots[index].UpdateSlot(items[index]);
    }

    public void UpdateAllSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            UpdateSlot(i);
        }
    }

    public void SelectItem(int index)
    {
        selecetedSlotIndex = index;
        selectedSlotItem = items[selecetedSlotIndex];

        Debug.Log(selecetedSlotIndex);

        if (!HasItem(selecetedSlotIndex))
            return;

        Debug.Log(1);

        if(selectedSlotItem.itemData.type == ItemType.Equipable)
        {
            if(!selectedSlotItem.equip)
                equipPopupUI.SetActive(true);
            else
                unEquipPopupUI.SetActive(true);
        }
        else if(selectedSlotItem.itemData.type == ItemType.Consumable)
        {
            usePopupUI.SetActive(true);
        }
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

    private void RemoveSelectedItem()
    {
        if (selectedSlotItem.equip)
        {
            if (selectedSlotItem.itemData.equipType == EquipType.Weapon)
            {
                _playerEquip.UnEquipWeapon();
                selectedSlotItem.equip = false;
            }
            else if (selectedSlotItem.itemData.equipType == EquipType.Armor)
            {
                _playerEquip.UnEquipArmor();
                selectedSlotItem.equip = false;
            }
        }

        selectedSlotItem.itemData = null;

        UpdateSlot(selecetedSlotIndex);
    }

    public void OnEquipButtonClick()
    {
        if(selectedSlotItem.itemData.equipType == EquipType.Weapon)
        {
            if(_playerEquip.IsEquipWeapon())
            {
                _playerEquip.UnEquipWeapon();
            }

            _playerEquip.EquipWeapon(selectedSlotItem);
        }
        else if(selectedSlotItem.itemData.equipType == EquipType.Armor)
        {
            if (_playerEquip.IsEquipArmor())
            {
                _playerEquip.UnEquipArmor();
            }

            _playerEquip.EquipArmor(selectedSlotItem);
        }

        UpdateAllSlot();
    }

    public void OnUnEquipButtonClick()
    {
        if (selectedSlotItem.itemData.equipType == EquipType.Weapon)
        {
            _playerEquip.UnEquipWeapon();
            selectedSlotItem.equip = false;
        }
        else if(selectedSlotItem.itemData.equipType == EquipType.Armor)
        {
            _playerEquip.UnEquipArmor();
            selectedSlotItem.equip = false;
        }

        UpdateAllSlot();
    }

    public void OnUseButtonClick()
    {
        for(int i = 0; i < selectedSlotItem.itemData.consumable.Length; i++)
        {
            switch(selectedSlotItem.itemData.consumable[i].type)
            {
                case ConsumableType.EXP:
                    _playerStat.AddExpValue((int)selectedSlotItem.itemData.consumable[i].value);
                    break;
                case ConsumableType.Health:
                    break;
            }
        }

        RemoveSelectedItem();
    }

    private void OnSlotButtonClick(int index)
    {
        SelectItem(index);
    }

    private bool HasItem(int index)
    {
        return items[index].itemData != null;
    }
}
