using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public FMODUnity.EventReference mainMenuAudioRef;
    private FMOD.Studio.EventInstance mainMenuAudioInst;

    public void Start()
    {
        mainMenuAudioInst = FMODUnity.RuntimeManager.CreateInstance(mainMenuAudioRef);
        mainMenuAudioInst.start();
    }



    public void NewGame(int i)
    {
        SceneController.LoadScene(i, 1, 2);
        mainMenuAudioInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
