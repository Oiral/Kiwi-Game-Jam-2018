using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCloseButtonScript : MonoBehaviour {

    private void Update()
    {
        if (InventoryScript.instance.weaponInventory.Count == 0){
            GetComponent<Button>().interactable = false;
        }else{
            GetComponent<Button>().interactable = true;
        }
    }
}
