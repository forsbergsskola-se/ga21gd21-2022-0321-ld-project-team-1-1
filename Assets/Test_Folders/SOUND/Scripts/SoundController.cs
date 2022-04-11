using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public FMODUnity.EventReference gravBeamRef;
    private FMOD.Studio.EventInstance gravBeamInst;
    // Start is called before the first frame update
    void Start()
    {
     gravBeamInst = FMODUnity.RuntimeManager.CreateInstance(gravBeamRef);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GravitygunAudio()
    {
        gravBeamInst.start();
    }
    public void GravitygunAudioStop()
    {
        gravBeamInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
