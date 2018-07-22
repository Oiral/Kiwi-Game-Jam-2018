using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTransitionScript : MonoBehaviour {

    public MenuScript menuScript;
    public float waitTime;
	// Use this for initialization
	void Start () {
        StartCoroutine( nextLevelPlease());
	}

    IEnumerator nextLevelPlease(){
        yield return new WaitForSeconds(waitTime);
        menuScript.LoadMainMenu();
    }
}
