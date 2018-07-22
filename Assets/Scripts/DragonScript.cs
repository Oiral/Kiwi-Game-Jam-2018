using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour {

    public int health = 260;
    public int maxHealth = 260;

    public int coinsPerHealth = 2;

    public Slider healthBar;
    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = other.gameObject.GetComponent<CrossBowThrow>().typeOfWeapon.damage;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.value = (float)health / (float)maxHealth;
            
        InventoryScript.instance.coins += coinsPerHealth * damage;
        if (InventoryScript.instance.weaponInventory.Count == 0){
            InventoryScript.instance.LoadShop();
        }else {
            //InventoryScript.instance.SpawnInRandomFromInventory();
        }

        Debug.Log(health.ToString());

    }


}
