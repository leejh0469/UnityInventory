using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Item Sell Info UI Component")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] private Button sellButton;
    [SerializeField] private TextMeshProUGUI sellButtonText;

    private void Start()
    {
        itemNameText.text = string.Empty;
        itemDescriptionText.text = string.Empty;
        itemPriceText.text = "0";
    }

    public void UpdateSellInfoUI(ShopItem item)
    {
        itemNameText.text = item.itemData.name;
        itemDescriptionText.text = item.itemData.description;
        itemPriceText.text = item.itemData.price.ToString();
        if (item.isSelled)
        {
            sellButtonText.text = "Sold Out";
            sellButton.interactable = false;
        }
        else
        {
            sellButtonText.text = "Buy";
            sellButton.interactable = true;
        }
    }
}
