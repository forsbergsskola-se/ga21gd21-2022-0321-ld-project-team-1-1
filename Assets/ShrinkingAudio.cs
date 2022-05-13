using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAudio : MonoBehaviour
{
    public FMODUnity.EventReference ShrinkingRef;
    private FMOD.Studio.EventInstance Shrinking�nst;
    FMOD.Studio.PLAYBACK_STATE pbState;
    public void OnTriggerEnter(Collider other)
    {
        Shrinking�nst.getPlaybackState(out pbState);
        if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING && ShopMenu.crouchPurchased == false)
        {
            Shrinking�nst = FMODUnity.RuntimeManager.CreateInstance(ShrinkingRef);
            Debug.Log("shrinkingUpgradeAudio");
            Shrinking�nst.start();
            Shrinking�nst.release();

        }
        else
        {


        }

    }












}
