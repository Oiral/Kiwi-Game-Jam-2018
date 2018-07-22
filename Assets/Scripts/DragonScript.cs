using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {

    public int health = 10;
    public int maxHealth = 10;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ouch");
        health -= 1;
    }


}
