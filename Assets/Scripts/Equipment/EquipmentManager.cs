using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public void Awake() {
        if(instance != null)
        {
            DontDestroyOnLoad(instance);
        }
        else
        {
            instance = this;
        }
    }
    
    [SerializeField] GameObject axe;
    [SerializeField] GameObject sword;
    [SerializeField] GameObject hammer;
    Weapon[] currentWeapon;
    Inventory inventory;

    public delegate void OnEquipmentChanged(Weapon newWeapon, Weapon oldWeapon);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start() {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(WeaponID)).Length;
        currentWeapon = new Weapon[numSlots];
    }

    public void Equip(Weapon newWeapon)
    {
        int slotIndex = (int)newWeapon.weapon;
        Weapon oldWeapon = Unequip(slotIndex);

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newWeapon,oldWeapon);
        }

        currentWeapon[slotIndex] = newWeapon;

        if(newWeapon != null && newWeapon.weapon == WeaponID.Axe)
        {
            axe.SetActive(true);
        }
        if(newWeapon != null && newWeapon.weapon == WeaponID.Sword)
        {
            sword.SetActive(true);
        }
        if(newWeapon != null && newWeapon.weapon == WeaponID.Hammer)
        {
            hammer.SetActive(true);
        }
    }

    public Weapon Unequip(int slotIndex)
    {
        if(currentWeapon[slotIndex] != null)
        {
            Weapon oldWeapon = currentWeapon[slotIndex];
            inventory.AddItem(oldWeapon);

            currentWeapon[slotIndex] = null;

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null,oldWeapon);
            }

            return oldWeapon;
        }

        return null;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

    private void UnequipAll()
    {
        axe.SetActive(false);
        sword.SetActive(false);
        hammer.SetActive(false);
    }
}
