using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JW.GAD210
{
    public class AplicationCloser : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        }
    } 
}
