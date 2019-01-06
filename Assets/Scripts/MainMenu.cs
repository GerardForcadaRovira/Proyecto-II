using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elemento
{
    public class MainMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AudioManager.instance.Play("Main Theme");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}