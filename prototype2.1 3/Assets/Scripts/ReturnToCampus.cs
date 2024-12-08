using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToCampus : MonoBehaviour
{
   public void ReturnCampus()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
