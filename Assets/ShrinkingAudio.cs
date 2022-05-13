using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAudio : MonoBehaviour
{
    public FMODUnity.EventReference ShrinkingRef;
    private FMOD.Studio.EventInstance ShrinkingÍnst;
    FMOD.Studio.PLAYBACK_STATE pbState;
    public void OnTriggerEnter(Collider other)
    {
        ShrinkingÍnst.getPlaybackState(out pbState);
        if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING && ShopMenu.crouchPurchased == false)
        {
            ShrinkingÍnst = FMODUnity.RuntimeManager.CreateInstance(ShrinkingRef);
            Debug.Log("shrinkingUpgradeAudio");
            ShrinkingÍnst.start();
            ShrinkingÍnst.release();

        }
        else
        {


        }

    }












}
