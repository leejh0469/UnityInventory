using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Item weaponItem;
    private Item armorItem;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        weaponItem = null;
        armorItem = null;
    }

    public void EquipWeapon(Item item)
    {
        weaponItem = item;
    }

    public void EquipArmor(Item item)
    {
        armorItem = item;
    }

    public void UnEquipWeapon() { weaponItem = null; }

    public void UnEquipArmor() {  armorItem = null; }

    public Item IsEquipWeapon()
    {
        if(weaponItem == null)
        {
            return null;
        }
        return weaponItem;
    }

    public Item IsEquipArmor()
    {
        if(armorItem == null)
        {
            return null;
        }
        return armorItem;
    }
}
