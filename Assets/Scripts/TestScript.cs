using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public MenuScript menuScript;

    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Lightning");
            menuScript.DefeatBoss();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("She's touching me!");
        //Replace Crossbow with explosion


        animator.SetTrigger("Lightning");
        menuScript.DefeatBoss();
    }

}
