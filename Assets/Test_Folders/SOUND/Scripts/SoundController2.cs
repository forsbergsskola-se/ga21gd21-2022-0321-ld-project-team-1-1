using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController2 : MonoBehaviour
{
    [Header("CrystalAudio")]
    //The Crystalharvest Beam
    public FMODUnity.EventReference gravBeamRef;
    private FMOD.Studio.EventInstance gravBeamInst;

    //Crystal audio for navigation 
    public FMODUnity.EventReference crystalAmbienceRef;
    private FMOD.Studio.EventInstance crystalAmbienceInst;

    //The Gravity Beam
    public FMODUnity.EventReference gravBeam2Ref;
    private FMOD.Studio.EventInstance gravBeam2Inst;

    //ErrorSound for when you cant lift object with gravitygun
    public FMODUnity.EventReference errorRef;
    private FMOD.Studio.EventInstance errorInst;


    //Audio filter for when the game is paused
    public FMODUnity.EventReference pauseFilterRef;
    private FMOD.Studio.EventInstance pauseFilterInst;

    //ComputerAudio

    public FMODUnity.EventReference enterShopRef;
    private FMOD.Studio.EventInstance enterShopInst;
    public FMODUnity.EventReference computerButtonRef;
    private FMOD.Studio.EventInstance computerButtonInst;

    [Header("Dialogue")]
    //Dialouge incrementer function
    public int dialougeIncr = 0;
    public FMODUnity.EventReference dialouge1_Ref;
    public FMODUnity.EventReference dialouge2_Ref;
    public FMODUnity.EventReference dialouge3_Ref;


    private FMOD.Studio.EventInstance dialougeInst;


    //JournalMonolog function
    public int journalNum = 0;
    public FMODUnity.EventReference journal1_Ref;
    public FMODUnity.EventReference journal2_Ref;
    public FMODUnity.EventReference journal3_Ref;
    public FMODUnity.EventReference journal4_Ref;


    private FMOD.Studio.EventInstance journalInst;

    [Header("NonLinearDialogue")]
    //NonLinear Dialogue
    public int NonLinearNum = 0;
    public FMODUnity.EventReference Nl1_Ref;
    public FMODUnity.EventReference Nl2_Ref;
    public FMODUnity.EventReference Nl3_Ref;
    public FMODUnity.EventReference Nl4_Ref;
    public FMODUnity.EventReference Nl5_Ref;
    public FMODUnity.EventReference Nl7_Ref;
    public FMODUnity.EventReference Nl8_Ref;
    public FMODUnity.EventReference S3_Ref;
    public FMODUnity.EventReference S4_Ref;
    public FMODUnity.EventReference S5_Ref;
    public FMODUnity.EventReference S8_Ref;
    public FMODUnity.EventReference S9_Ref;

    private FMOD.Studio.EventInstance Nl1Inst;
    private FMOD.Studio.EventInstance Nl2Inst;
    private FMOD.Studio.EventInstance Nl3Inst;
    private FMOD.Studio.EventInstance Nl4Inst;
    private FMOD.Studio.EventInstance Nl5Inst;
    private FMOD.Studio.EventInstance Nl7Inst;
    private FMOD.Studio.EventInstance Nl8Inst;
    private FMOD.Studio.EventInstance S3Inst;
    private FMOD.Studio.EventInstance S4Inst;

    private FMOD.Studio.EventInstance NonLinearInst;

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
        crystalAmbienceInst.release();
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
    public void Journal()
    {
        if (journalNum == 1)
        {
            journalInst = FMODUnity.RuntimeManager.CreateInstance(journal1_Ref);
        }
        else if (journalNum == 2)
        {
            journalInst = FMODUnity.RuntimeManager.CreateInstance(journal2_Ref);
        }
        else if (journalNum == 3)
        {
            journalInst = FMODUnity.RuntimeManager.CreateInstance(journal3_Ref);
        }
        else if (journalNum == 4)
        {
            journalInst = FMODUnity.RuntimeManager.CreateInstance(journal4_Ref);
        }

        journalInst.start();
        journalInst.release();

    }
    public void DestroyWaterFilter1_Audio()
    {
        Nl2Inst = FMODUnity.RuntimeManager.CreateInstance(Nl2_Ref);
        Nl2Inst.start();
        Nl2Inst.release();

    }
    public void WaterFilter2_Audio()
    {
        Nl3Inst = FMODUnity.RuntimeManager.CreateInstance(Nl3_Ref);
        Nl3Inst.start();
        Nl3Inst.release();

    }
    public void DestroyWaterFilter2_Audio()
    {
        Nl4Inst = FMODUnity.RuntimeManager.CreateInstance(Nl4_Ref);
        Nl4Inst.start();
        Nl4Inst.release();


    }
    public void FindingresourcesAudio()
    {
        Nl5Inst = FMODUnity.RuntimeManager.CreateInstance(Nl5_Ref);
        Nl5Inst.start();
        Nl5Inst.release();

    }
    public void Puzzle1_Audio()
    {
        Nl7Inst = FMODUnity.RuntimeManager.CreateInstance(Nl7_Ref);
        Nl7Inst.start();
        Nl7Inst.release();
    }
    public void Puzzle2_Audio()
    {
        Nl8Inst = FMODUnity.RuntimeManager.CreateInstance(Nl8_Ref);
        Nl8Inst.start();
        Nl8Inst.release();
    }

    public void ShopDialogue()
    {
        Nl1Inst = FMODUnity.RuntimeManager.CreateInstance(Nl1_Ref);
        Nl1Inst.start();
        Nl1Inst.release();
    }
    public void ApproachingCampAudio()
    {
        S3Inst = FMODUnity.RuntimeManager.CreateInstance(S3_Ref);
        S3Inst.start();
        S3Inst.release();
    }
    public void InCampAudio()
    {
        S4Inst = FMODUnity.RuntimeManager.CreateInstance(S4_Ref);
        S4Inst.start();
        S4Inst.release();
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

    public void enterShopAudio()
    {
        enterShopInst = FMODUnity.RuntimeManager.CreateInstance(enterShopRef);
        enterShopInst.start();
        enterShopInst.release();
    }
    public void computerButtonAudio()
    {
        computerButtonInst = FMODUnity.RuntimeManager.CreateInstance(computerButtonRef);
        computerButtonInst.start();
        computerButtonInst.release();
    }
}
