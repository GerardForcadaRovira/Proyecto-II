using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerInteracts : MonoBehaviour {

    public BoxCollider interact;
    public Transform player;
    public Vector3 maxDistance;
    public Text textButton;
    public Text textPressed;
    //Para cada caso necesitamos un bool para el estado, el GameObject, un tiempo de inicio y si queremos que en un tiempo vuelva a su estado inicial una diferencia de tiempo
    bool isPressed = false;
    public GameObject itemInteract;
    float initTime;
    public float spawnedTime = 5;

	// Use this for initialization
	void Start () {
        itemInteract.SetActive(isPressed);//inicializamos el estado del G.O. como desactivado
	}
	
	// Update is called once per frame
	void Update () {
        itemInteract.SetActive(isPressed);//actualizamos el estado y a continuacion determinamos el rango
        if ((player.position.y + maxDistance.y >= interact.center.y - (interact.size.y / 2)) && (player.position.y - maxDistance.y <= interact.center.y + (interact.size.y / 2)))
        {
            
            if ((player.position.x + maxDistance.x >= interact.center.x - (interact.size.x / 2))&& (player.position.x - maxDistance.x <= interact.center.x + (interact.size.x / 2)))
            {
                
                if ((player.position.z + maxDistance.z >= interact.center.z - (interact.size.z / 2)) && (player.position.z - maxDistance.z <= interact.center.z + (interact.size.z / 2)))
                {
                    //Debug.Log("Rango");
                    if (Input.GetKey(KeyCode.E))//tecla para activacion
                    {
                        //Debug.Log("Activado");
                        isPressed = true;
                        initTime = Time.time;
                    }

                    if((initTime + spawnedTime) <= Time.time)//control del tiempo en escena
                    {
                        isPressed = false;
                    }

                }

            }

        }

	}
}
