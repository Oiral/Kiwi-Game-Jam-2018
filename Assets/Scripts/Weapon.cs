using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public Sprite sprite;
    public int cost;
    public int damage;
    public string name;

    public Weapon(Sprite spriteOfWeapon,int costOfWeapon,int damageOfWeapon,string nameOfWeapon){
        sprite = spriteOfWeapon;
        cost = costOfWeapon;
        damage = damageOfWeapon;
        name = nameOfWeapon;
    }
}
