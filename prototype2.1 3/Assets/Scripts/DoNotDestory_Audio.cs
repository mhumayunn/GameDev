using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        GameObject[] audio_obj = GameObject.FindGameObjectsWithTag("Audio");
        if(audio_obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
