using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right, 30 * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        playerStats.hasItem = true;
        Destroy(this.gameObject);
    }
}
