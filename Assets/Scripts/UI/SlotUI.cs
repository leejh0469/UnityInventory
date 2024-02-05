using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public int index {  get; private set; }

    [SerializeField] private Image icon;
    [SerializeField] private GameObject _equipText;

    private GameObject _iconGO;

    public Action<int> OnButtonClickAction;

    private void Awake()
    {
        _iconGO = icon.gameObject;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void Clear()
    {
        _iconGO.SetActive(false);
        _equipText.SetActive(false);
    }

    public void UpdateSlot(Item item)
    {
        _iconGO?.SetActive(true);
        icon.sprite = item.itemData.icon;

        if (item.equip)
            _equipText.SetActive(true);
        else
            _equipText.SetActive(false);
    }

    public void UpdateSlot(ItemData item)
    {
        _iconGO?.SetActive(true);
        icon.sprite = item.icon;
    }

    public void OnButtonClick()
    {
        OnButtonClickAction?.Invoke(index);
    }
}
