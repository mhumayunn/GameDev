using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : MonoBehaviour
{
    public GameObject panel;

    public void OpenSettings()
    {
        if (panel != null)
        {
            panel.SetActive(true); 
        }
    }

    public void CloseSettings() 
    {
        if (panel != null)
        {
            panel.SetActive(false); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
