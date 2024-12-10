using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    public List<GameObject> screensPrimary   = new List<GameObject>();
    public List<GameObject> screensSecondary = new List<GameObject>();
    public List<KeyCode> keys = new List<KeyCode>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    if (screensPrimary[i].activeSelf)
                    {
                        screensPrimary[i].SetActive(false);
                        screensSecondary[i].SetActive(true);
                    }
                    else
                    {
                        screensPrimary[i].SetActive(true);
                        screensSecondary[i].SetActive(false);
                    }
                }
            }
        }
    }
}
