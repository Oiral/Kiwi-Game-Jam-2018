using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryScript : MonoBehaviour {

    public List<Weapon> weaponInventory = new List<Weapon>();
    public GameObject weaponPrefab;
    public int coins;

    public GameObject visualInventory;
    private List<GameObject> visualInventoryPanels = new List<GameObject>();
    public GameObject visualPanel;

    public GameObject shopPanel;
    public bool shopActive;

    public static InventoryScript instance;
    private void Awake()
    {
        if (instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }
        weaponInventory.Add(GetComponent<ShopScript>().crossbow);
    }


    //Replace all game objects with sprite stuff!!!!



    public bool PurchaseItem(Weapon weaponToAdd) 
    {
        if (weaponToAdd.cost <= coins)
        {
            weaponInventory.Add(weaponToAdd);
            Debug.Log("You have purchased a " + weaponToAdd.name);
            coins -= weaponToAdd.cost;
            UpdateVisualUI();
            return true;                
        }else{
            Debug.Log("Not enough money to purchase");
            return false;
        }

    }

    public void RemoveItem(Weapon weaponToRemove)
    {
        if (weaponInventory.Contains(weaponToRemove))
        {
            
            Debug.Log("Removing Weapon");
            weaponInventory.Remove(weaponToRemove);
        }else
        {
            Debug.Log("Could not find the weapon. Not removing anything");
        }
        UpdateVisualUI();
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
        Weapon randomWeapon = weaponInventory[Random.Range(0, weaponInventory.Count)];

        //Now we have our random item spawn it in
        GameObject weapon = Instantiate(weaponPrefab, inventorySlot.transform.position, Quaternion.identity, null);
        weapon.GetComponent<SpriteRenderer>().sprite = randomWeapon.sprite;
        //Remove the random item so it's not in our inventory anymore

        RemoveItem(randomWeapon);
        weapon.GetComponent<CrossBowThrow>().beingThrown = true;
        weapon.GetComponent<CrossBowThrow>().typeOfWeapon = randomWeapon;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !shopActive){
            SpawnInRandomFromInventory();
        }
    }

    void UpdateVisualUI(){
        //Check if there are enough slots for the weapons
        int diff = weaponInventory.Count - visualInventoryPanels.Count;
        if (diff > 0)
        {
            //Add some more panels for each iteration of diff until diff = 0
            for (int i = diff; i > 0; i--)
            {
                GameObject panel = Instantiate(visualPanel, visualInventory.transform);
                visualInventoryPanels.Add(panel);
            }
        
        }else if (diff < 0){
            //Remove panels unity diff = 0
            for (int i = diff; i < 0; i++)
            {
                GameObject panel = visualInventoryPanels[0];
                visualInventoryPanels.Remove(panel);
                Destroy(panel);
            }
        }



        for (int i = 0; i < visualInventoryPanels.Count; i++)
        {
            visualInventoryPanels[i].GetComponentsInChildren<Image>()[1].sprite = weaponInventory[i].sprite;
        }
    }

    public void LoadShop()
    {
        shopPanel.SetActive(true);
        shopActive = true;
    }

    public void UnLoadShop()
    {
        //SpawnInRandomFromInventory();
        shopPanel.SetActive(false);
        shopActive = false;
    }
}
