using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public BoxCollider floor;
    public GameObject ene1, ene2, ene3;

    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.name == "vThirdPersonController")
        {
            Debug.Log("detecta");
            if (ene1.activeInHierarchy)
            {
                block.SetActive(true);
            }
            block.SetActive(false);
        }
    }



}
