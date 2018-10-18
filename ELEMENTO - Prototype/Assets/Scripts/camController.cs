using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;


	// Use this for initialization
	void Start () {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("MouseX") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("MouseY") * rotateSpeed;
        target.Rotate(-vertical, 0, 0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        transform.LookAt(target);
	}
}
