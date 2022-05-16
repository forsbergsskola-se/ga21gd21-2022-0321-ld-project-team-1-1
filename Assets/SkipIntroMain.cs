using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntroMain : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SceneController.LoadScene(0, 1, 2);
        
    }
}
