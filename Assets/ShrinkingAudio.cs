using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAudio : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public FMODUnity.EventReference ShrinkingRef;
    private FMOD.Studio.EventInstance ShrinkingInst;
    FMOD.Studio.PLAYBACK_STATE pbState;
    public void OnTriggerEnter(Collider other)
    {
        ShrinkingInst.getPlaybackState(out pbState);
        if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING && ShopMenu.crouchPurchased == false)
        {
            ShrinkingInst = FMODUnity.RuntimeManager.CreateInstance(ShrinkingRef);
            Debug.Log("shrinkingUpgradeAudio");
            ShrinkingInst.start();
            anim.SetBool("isTalking", true);
            ShrinkingInst.release();
            anim.SetBool("isTalking", false);

        }
        else
        {


        }

    }












}
