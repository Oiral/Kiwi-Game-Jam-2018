using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowThrow : MonoBehaviour {

    public AnimationCurve throwCurve;

    public GameObject explosionPrefab;

    public Weapon typeOfWeapon;

    public bool beingThrown = false;
    // Update is called once per frame

    Vector3 startingPos;
    float currentMoveFrame = 0f;
    public float scale = 0.1f;
    public int totalFrames;
    private void Start()
    {
        startingPos = transform.position;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            beingThrown = true;
        }

        if (beingThrown){

            float height = throwCurve.Evaluate(currentMoveFrame / (float)totalFrames);

            Vector3 evalPos = new Vector3(currentMoveFrame / (float)totalFrames, height);
            evalPos = evalPos * scale;

            Vector3 pos = startingPos;
            pos = pos + evalPos;

            transform.position = pos;

            currentMoveFrame += 1f;

            if (currentMoveFrame > totalFrames){
                beingThrown = false;
                currentMoveFrame = 0;
            }

        }

	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject explosion = Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.identity, null);
        Destroy(gameObject);

        Destroy(explosion, 2);
    }
}
