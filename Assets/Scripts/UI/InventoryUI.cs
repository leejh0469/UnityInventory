using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotsParent;
    private SlotUI[] slots;


    private void Awake()
    {
        slots = slotsParent.GetComponentsInChildren<SlotUI>();

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].SetIndex(i);
            slots[i].Clear();
        }
    }

}
