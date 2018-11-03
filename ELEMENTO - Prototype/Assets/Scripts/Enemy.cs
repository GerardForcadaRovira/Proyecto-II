using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject drop;
    public int health = 100;
    private Vector3 dropPos;

	// Use this for initialization
	void Start () {
        dropPos = this.transform.position;
        dropPos.y += 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(drop, dropPos, Quaternion.identity);
        }
	}
}
