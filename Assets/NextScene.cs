using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneController.LoadScene(2, 1, 2);
    }
}
