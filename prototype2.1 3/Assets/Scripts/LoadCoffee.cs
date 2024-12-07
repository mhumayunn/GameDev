using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartLoadingProcess()
    {
        SceneManager.LoadScene("CoffeeOrderLoading");
    }
}
