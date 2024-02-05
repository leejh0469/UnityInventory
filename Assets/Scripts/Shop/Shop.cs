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
        }
    }

}
