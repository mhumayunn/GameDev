using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InLoadingBakery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadCCPanelAfterDelay());
    }

    IEnumerator LoadCCPanelAfterDelay()
    {
        // waiting for 3 seconds
        yield return new WaitForSeconds(3f);

        // Loading the "CCPanel" scene
        SceneManager.LoadScene("CCPanel");
    }

}
