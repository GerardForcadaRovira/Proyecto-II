using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elemento
{
    public class GameManager : MonoBehaviour
    {
        public GameObject PauseUI;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        }

        private void Pause()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseUI.SetActive(true);
        }

        public void UnPause()
        {
            Cursor.lockState = CursorLockMode.Locked;
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}