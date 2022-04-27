using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    void Update()
    {
        if (TapDestroy.waterFilterCount >= 3)
        {
            //SceneManager.LoadScene(sceneBuildIndex: 2);
            Debug.Log("ending");
        }
            
    }
}
