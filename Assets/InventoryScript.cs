using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : MonoBehaviour {

    public List<Sprite> weaponInventory = new List<Sprite>();

    public static InventoryScript instance;

    public GameObject weaponPrefab;

    public GameObject shopPanel;

    private void Awake()
    {
        if (instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }
    }


    //Replace all game objects with sprite stuff!!!!



    public void PurchaseItem(Sprite weaponSprite) 
    {
        weaponInventory.Add(weaponSprite);
        Debug.Log("You have purchased a " + weaponSprite.name);
    }

    public void RemoveItem(Sprite weapon)
    {
        if (weaponInventory.Contains(weapon))
        {
            
            Debug.Log("Removing Weapon");
            weaponInventory.Remove(weapon);
        }else
        {
            Debug.Log("Could not find the weapon. Not removing anything");
        }
    }

    public void SpawnInRandomFromInventory()
    {
        //Check if there is an item in our inventory
        if (weaponInventory.Count == 0){
            Debug.Log("Inventory is empty");
            //At this point show the shop

            return;
        }
        //Find the inventory slot we can spawn the item too
        GameObject inventorySlot = GameObject.FindGameObjectWithTag("InventorySlot");
        if (inventorySlot == null){
            Debug.Log("Could not find an invetory to spawn item in with");
            return;
        }

        //Get a random item from our inventory
        int randnum = Random.Range(1, weaponInventory.Count);
        Sprite randomWeapon = weaponInventory[Random.Range(0, weaponInventory.Count)];

        //Now we have our random item spawn it in
        GameObject weapon = Instantiate(weaponPrefab, inventorySlot.transform.position, Quaternion.identity, null);
        weapon.GetComponent<SpriteRenderer>().sprite = randomWeapon;
        //Remove the random item so it's not in our inventory anymore

        RemoveItem(randomWeapon);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            SpawnInRandomFromInventory();
        }
        if (Input.GetKeyDown(KeyCode.H)){
            LoadShop();
        }
        if (Input.GetKeyDown(KeyCode.J)){
            UnLoadShop();
        }
    }

    public void LoadShop()
    {
        shopPanel.SetActive(true);
    }

    public void UnLoadShop()
    {
        shopPanel.SetActive(false);
    }
}
