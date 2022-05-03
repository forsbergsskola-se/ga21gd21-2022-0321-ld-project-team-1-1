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
    public FMODUnity.EventReference errorRef;
    private FMOD.Studio.EventInstance errorInst;

    //Crystal audio for navigation 
    public FMODUnity.EventReference crystalAmbienceRef;
    private FMOD.Studio.EventInstance crystalAmbienceInst;

    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;




    //Dialouge incrementer function
    public int dialougeIncr = 0;
    public FMODUnity.EventReference dialouge1_Ref;
    public FMODUnity.EventReference dialouge2_Ref;
    public FMODUnity.EventReference dialouge3_Ref;
    public FMODUnity.EventReference dialouge4_Ref;
    public FMODUnity.EventReference dialouge5_Ref;
    public FMODUnity.EventReference dialouge6_Ref;
    public FMODUnity.EventReference dialouge7_Ref;
    public FMODUnity.EventReference dialouge8_Ref;
    public FMODUnity.EventReference dialouge9_Ref;
    public FMODUnity.EventReference dialouge10_Ref;

    private FMOD.Studio.EventInstance dialougeInst;


    void Start()
    {
        gravBeamInst = FMODUnity.RuntimeManager.CreateInstance(gravBeamRef);
        gravBeam2Inst = FMODUnity.RuntimeManager.CreateInstance(gravBeam2Ref);
        errorInst = FMODUnity.RuntimeManager.CreateInstance(errorRef);
        crystalAmbienceInst = FMODUnity.RuntimeManager.CreateInstance(crystalAmbienceRef);

        //Dialouge



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
        errorInst.start();
    }
    public void ErrorSoundStop()
    {
        errorInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void CrystalAmbAudio()
    {
        crystalAmbienceInst.start();
    }
    public void CrystalAmbStop()
    {
        crystalAmbienceInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void DialougePlayer()
    {
        dialougeIncr++;

        if (dialougeIncr == 1)
        {
            Debug.Log("playDialouge_1");
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(dialouge1_Ref);
        }
        else if (dialougeIncr == 2)
        {
            dialougeInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(dialouge2_Ref);
            Debug.Log("playDialouge_2");
        }
        dialougeInst.start();
        dialougeInst.release();


    }
    public void PauseMenu()
    {
        pauseFilterInst = FMODUnity.RuntimeManager.CreateInstance("snapshot:/PauseFilter");
        pauseFilterInst.start();
    }
    public void PauseMenuStop()
    {
        pauseFilterInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    
}
