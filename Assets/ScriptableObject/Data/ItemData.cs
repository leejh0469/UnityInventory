using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum EquipType
{
    Weapon,
    Armor
}

public enum ConsumableType
{
    Health,
    EXP
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string name;
    public ItemType type;
    [Multiline]
    public string description;
    public Sprite icon;

    [Header("Equip")]
    public EquipType equipType;
    public float attackValue;
    public float defenceValue;

    [Header("Consume")]
    public ItemDataConsumable[] consumable;
}
