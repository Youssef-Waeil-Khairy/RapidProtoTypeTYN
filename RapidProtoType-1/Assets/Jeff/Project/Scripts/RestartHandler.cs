using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jeff.Project3.RestartHandler 
{
   
    public class RestartHandler : MonoBehaviour
    {
        public AudioSource bloodSplatter; //AudioSource for the blood
        private void Start()
        {
            bloodSplatter.Play();
        }
        void RestartGame()
        {
            SceneManager.LoadScene("Warehouse");
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.R)) 
            {
                RestartGame();
            }
        }
    }
}

