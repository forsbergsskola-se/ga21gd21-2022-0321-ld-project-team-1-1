using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour
{
    private void OnEnable()
    {
        SceneController.LoadScene(0, 1, 2);
    }
}
