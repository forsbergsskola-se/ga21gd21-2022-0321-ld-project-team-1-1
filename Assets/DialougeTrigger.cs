using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public SoundController sc;
    FMOD.Studio.PLAYBACK_STATE pbState;

    private void OnTriggerEnter(Collider Other)
    {
        sc.dialougeInst.getPlaybackState(out pbState);
        if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            Debug.Log("DialougeCollision");

            sc.DialougePlayer();
            //anim.SetBool("isTalking", true);
            Debug.Log("DestroyObject");
            Destroy(gameObject);
            

        }
        else
        {

        }

    }


}
