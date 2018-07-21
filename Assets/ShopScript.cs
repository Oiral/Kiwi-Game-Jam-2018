using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public Sprite crossbowSprite;

    public Sprite swordSprite;




    #region shopfunctions

    public void BuyCrossbow(){
        //Maybe check if the player has enough money?
        InventoryScript.instance.PurchaseItem(crossbowSprite);
    }

    public void BuySword(){
        InventoryScript.instance.PurchaseItem(swordSprite);
    }
    #endregion
}
