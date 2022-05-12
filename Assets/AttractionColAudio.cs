using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionColAudio : MonoBehaviour
{
    public SoundController sc;
    FMOD.Studio.PLAYBACK_STATE pbState;
    public void OnTriggerEnter(Collider other)
    {
        sc.dialougeInst.getPlaybackState(out pbState);
        if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING && ShopMenu.gravityGunPurchased == false)
        {
            Debug.Log("journaTrigger");
            sc.AttractionGlove();
            Debug.Log("DestroyObject");
            Destroy(gameObject);        

        }
        else
        {

        }

    }

}
