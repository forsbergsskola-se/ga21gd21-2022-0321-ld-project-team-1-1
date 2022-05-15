using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    [SerializeField] private int maxFinters = 4;
    void Update()
    {
        if (TapDestroy.waterFilterCount >= maxFinters)
        {
            SceneController.LoadScene(3, 1, 1);
        }
            
    }
}
