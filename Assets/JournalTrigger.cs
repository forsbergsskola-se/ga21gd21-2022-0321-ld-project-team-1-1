using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalTrigger : MonoBehaviour
{
    public SoundController sc;
    FMOD.Studio.PLAYBACK_STATE pbState;

    public void OnTriggerEnter(Collider other)
    {
        sc.journalInst.getPlaybackState(out pbState);
        if(pbState!= FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            Debug.Log("journaTrigger");
            sc.Journal();
            Debug.Log("DestroyObject");
            Destroy(gameObject);


        }
        else
        {

        }

    }

}
