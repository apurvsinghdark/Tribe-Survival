using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public WeaponID weapon;
    public int damage;

    public override void Use()
    {
        base.Use();

        RemoveFromInventory();
    }
}
public enum WeaponID{ Axe , Sword , Hammer}
