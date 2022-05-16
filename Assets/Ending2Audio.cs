using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2Audio : MonoBehaviour
{
    public FMODUnity.EventReference AudioRef;
    public FMOD.Studio.EventInstance AudioInst;
    void Start()
    {
        AudioInst = FMODUnity.RuntimeManager.CreateInstance(AudioRef);
        AudioInst.start();

    }
    public void stopAudio()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            AudioInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            AudioInst.release();
        }

    }

}
