using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void NewGame(int i)
    {
        SceneController.LoadScene(i, 1, 2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
