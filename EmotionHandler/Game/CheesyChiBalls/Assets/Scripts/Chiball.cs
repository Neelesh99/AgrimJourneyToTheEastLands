using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiball : MonoBehaviour {
    public float chiSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(chiSpeed * Vector2.right * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D target)
    {

        //Destroy(target.gameObject);
    }

}
