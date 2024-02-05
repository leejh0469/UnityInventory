using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Item weaponItem;
    private Item armorItem;

    private Inventory _inventory;

    private PlayerStat _playerStat;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _playerStat = GetComponent<PlayerStat>();
        weaponItem = null;
        armorItem = null;
    }

    public void EquipWeapon(Item item)
    {
        weaponItem = item;
        weaponItem.equip = true;
        _playerStat.AddAttackValue(weaponItem.itemData.attackValue);
    }

    public void EquipArmor(Item item)
    {
        armorItem = item;
        armorItem.equip = true;
        _playerStat.AddDefenceValue(armorItem.itemData.defenceValue);
    }

    public void UnEquipWeapon() 
    { 
        _playerStat.SubtractAttackValue(weaponItem.itemData.attackValue);
        weaponItem.equip = false;
        weaponItem = null; 
    }

    public void UnEquipArmor() 
    {
        _playerStat.SubtractDefenceValue(armorItem.itemData.defenceValue);
        armorItem.equip = false;
        armorItem = null; 
    }

    public bool IsEquipWeapon() { return weaponItem == null ? false : true; }

    public bool IsEquipArmor() { return armorItem == null ? false : true; }
}
