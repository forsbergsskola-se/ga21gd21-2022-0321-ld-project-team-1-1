using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Animator anim;
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
    bool destroyAudio = false;
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


    public FMOD.Studio.EventInstance dialougeInst;


    //JournalMonolog function
    public int journalNum = 0;
    
    public FMODUnity.EventReference journal1_Ref;
    public FMODUnity.EventReference journal2_Ref;
    public FMODUnity.EventReference journal3_Ref;
    public FMODUnity.EventReference journal4_Ref;


    public FMOD.Studio.EventInstance journalInst;

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

    //private FMOD.Studio.EventInstance Nl1Inst;
    //private FMOD.Studio.EventInstance Nl2Inst;
    //private FMOD.Studio.EventInstance Nl3Inst;
    //private FMOD.Studio.EventInstance Nl4Inst;
    //private FMOD.Studio.EventInstance Nl5Inst;
    //private FMOD.Studio.EventInstance Nl7Inst;
    //private FMOD.Studio.EventInstance Nl8Inst;
    //private FMOD.Studio.EventInstance S3Inst;
    //private FMOD.Studio.EventInstance S4Inst;

    public FMOD.Studio.EventInstance NonLinearInst;
    FMOD.Studio.PLAYBACK_STATE pbState;
    //public bool hasPLayed = false;

    //AttractionGlove Audio
    public FMODUnity.EventReference Ag1_ref;


    //crouchbool
    private bool crouchActivaded = false;

    public FMODUnity.EventReference Sh4Ref;
    private FMOD.Studio.EventInstance sh4Inst;
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
        else if (dialougeIncr == 3)
        {
            dialougeInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(dialouge2_Ref);
            Debug.Log("playDialouge_3");

        }
        dialougeInst.start();
        anim.SetBool("isTalking", true);
        dialougeInst.release();
        anim.SetBool("isTalking", false);


    }
    public void Journal()
    {
        journalNum++;

        if (journalNum == 1)
        {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(journal1_Ref);
        }
        else if (journalNum == 2)
        {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(journal2_Ref);
        }
        else if (journalNum == 3)
        {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(journal3_Ref);
        }
        else if (journalNum == 4)
        {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(journal4_Ref);
        }

        dialougeInst.start();
        anim.SetBool("isTalking", true);
        dialougeInst.release();
        anim.SetBool("isTalking", false);

    }
    public void AttractionGlove()
    {
        dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Ag1_ref);
        dialougeInst.start();
        anim.SetBool("isTalking", true);
        dialougeInst.release();
        anim.SetBool("isTalking", false);

    }
    public void NonLinearAudio()
    {

        anim.SetBool("isTalking", true);
        //NonLinearInst.getPlaybackState(out pbState);

        //if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        //{
        if (NonLinearNum == 1)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl2_Ref);

                //Destroying the first Water Filter
            }
            else if (NonLinearNum == 2)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl3_Ref);
                //The 2nd water filter Filter

            }
            else if (NonLinearNum == 3)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl4_Ref);
                //Destroying the 2nd Water Filter

            }
            else if (NonLinearNum == 4)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl5_Ref);
                //Finding resources

            }
            else if (NonLinearNum == 5)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl7_Ref);
                //Puzzle #1 Solved

            }
            else if (NonLinearNum == 6)
            {
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(Nl8_Ref);
                //Puzzle #2 

            }
            else if (NonLinearNum == 7)
            {
            //Trigger enter
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(S3_Ref);
            }
            else if (NonLinearNum == 7)
            {
            //setting out from camp
            }
            else if (NonLinearNum == 8)
            {
            //in camp
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(S4_Ref);
            }
            else if (NonLinearNum == 9)
            {
            //Open World
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(S8_Ref);
            }
            else if (NonLinearNum == 10)
            {
            //Kelta's Approach from the Ship
            dialougeInst = FMODUnity.RuntimeManager.CreateInstance(S9_Ref);
            }

            dialougeInst.start();
            //hasPlayed Bool? 
            dialougeInst.release();


        //}
    }

    public void ShopDialogue()
    {
        if (destroyAudio == false)
        {
        NonLinearInst = FMODUnity.RuntimeManager.CreateInstance(Nl1_Ref);
        NonLinearInst.start();
        anim.SetBool("isTalking", true);
        NonLinearInst.release();
        anim.SetBool("isTalking", false);
        destroyAudio = true;
        }
        else
        {

        }

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
    public void crouchAudio()
    {
        if (ShopMenu.crouchPurchased == true && crouchActivaded == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                sh4Inst = FMODUnity.RuntimeManager.CreateInstance(Sh4Ref);
                Debug.Log("shrinkingOnceAudio");
                sh4Inst.start();
                sh4Inst.release();
                crouchActivaded = true;


            }


        }
    }
}
