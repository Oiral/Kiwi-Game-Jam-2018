using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [Header("Crossbow")]
    public Sprite crossbowSprite;
    public Weapon crossbow;

    [Header("Sword")]
    public Sprite swordSprite;
    public Weapon sword;

    [Header("Golden Sword")]
    public Sprite goldenSwordSprite;
    public Weapon goldenSword;


    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        crossbow = new Weapon(crossbowSprite, 1, 1, "Crossbow");

        sword = new Weapon(swordSprite, 10, 8, "Sword");

        goldenSword = new Weapon(goldenSwordSprite, 50, 100, "Golden Sword");
        audioSource = GetComponent<AudioSource>();
    }
    #region shopfunctions

    public void BuyCrossbow(){
        //Maybe check if the player has enough money?
        InventoryScript.instance.PurchaseItem(crossbow);
        audioSource.PlayOneShot(clip);
    }

    public void BuySword(){
        InventoryScript.instance.PurchaseItem(sword);
        audioSource.PlayOneShot(clip);
    }

    public void BuyGoldenSword(){
        InventoryScript.instance.PurchaseItem(goldenSword);
        audioSource.PlayOneShot(clip);
    }
    #endregion
}
