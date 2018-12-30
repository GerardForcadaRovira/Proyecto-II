using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour {

    #region Variables
    public int speed;
    public float lifeTime;
	#endregion
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * speed * Time.deltaTime);
	}
}
