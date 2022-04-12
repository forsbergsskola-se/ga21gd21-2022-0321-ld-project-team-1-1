using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //The Crystalharvest Beam
    public FMODUnity.EventReference gravBeamRef;
    private FMOD.Studio.EventInstance gravBeamInst;

    //The Gravity Beam
    public FMODUnity.EventReference gravBeam2Ref;
    private FMOD.Studio.EventInstance gravBeam2Inst;

    //ErrorSound for when you cant lift object with gravitygun
    public FMODUnity.EventReference ErrorRef;
    private FMOD.Studio.EventInstance ErrorInst;

    void Start()
    {
        gravBeamInst = FMODUnity.RuntimeManager.CreateInstance(gravBeamRef);
        gravBeam2Inst = FMODUnity.RuntimeManager.CreateInstance(gravBeam2Ref);

    }

    void Update()
    {
        
    }
    public void GravitygunAudio() //Crystal Harvest
    {
        gravBeamInst.start();
    }
    public void GravitygunAudioStop() //Crystal Harvest
    {
        gravBeamInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void Gravitygun2Audio() //Gravity Beam
    {
        gravBeam2Inst.start();
    }
    public void Gravitygun2AudioStop() //Gravity Beam
    {
        gravBeam2Inst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void ErrorSound()
    {
        ErrorInst.start();
    }
    public void ErrorSoundStop()
    {
        ErrorInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
