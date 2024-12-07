using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameTime gameTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        SceneManager.LoadSceneAsync("Main Scene");
    }

    public void BackToMenu()
    {
        if (gameTime != null)
        {
            gameTime.ResetTimer(); 
        }
        SceneManager.LoadSceneAsync("Menu scene");
    }
}
