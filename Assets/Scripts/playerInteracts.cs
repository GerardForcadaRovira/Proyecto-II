using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerInteracts : MonoBehaviour {

    public BoxCollider interact;
    public Transform player;
    public float rangeDistance;
    private Vector3 range;
    public GameObject textButton;
    public Text textPressed;
    //Para cada caso necesitamos un bool para el estado, el GameObject, un tiempo de inicio y si queremos que en un tiempo vuelva a su estado inicial una diferencia de tiempo
    bool isPressed = false;
    public GameObject itemInteract;
    public GameObject itemInteract2;
    float initTime;
    public float spawnedTime = 5;

    public GameObject itemTextNo;
    public GameObject itemTextYes;

	// Use this for initialization
	void Start () {
        itemInteract.SetActive(isPressed);//inicializamos el estado del G.O. como desactivado
        range.x = transform.position.x + rangeDistance;
        range.y = transform.position.y + rangeDistance;
        range.z = transform.position.z + rangeDistance;
        
	}
	
	// Update is called once per frame
	void Update () {
        itemInteract.SetActive(isPressed);//actualizamos el estado y a continuacion determinamos el rango
        if (itemInteract2 != null)
        {
            itemInteract2.SetActive(isPressed);
            itemTextNo.SetActive(false);
            itemTextYes.SetActive(false);
        }

        if (player.position.x < range.x && player.position.y < range.y && player.position.z < range.z)
        {
            textButton.SetActive(true);

            if (Input.GetKey(KeyCode.E) && playerStats.hasItem)//tecla para activacion
            {
                if (itemInteract2 != null)
                {
                    StartCoroutine(showDiag(itemTextYes));
                }
                
                isPressed = true;
            }
            else if (Input.GetKey(KeyCode.E) && itemInteract2 != null)
            {
                StartCoroutine(showDiag(itemTextNo));
            }
        }
        else
        {
            textButton.SetActive(false);
        }
	}

    IEnumerator showDiag(GameObject diag)
    {
        textButton.SetActive(false);
        diag.SetActive(true);
        yield return new WaitForSeconds(3);
        diag.SetActive(false);
    }
}
