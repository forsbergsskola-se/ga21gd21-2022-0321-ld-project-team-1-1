using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audiotrigger : MonoBehaviour
{
    
    public SoundController sc;
    public int funcNum = 0;
    FMOD.Studio.PLAYBACK_STATE pbState;


    public void OnTriggerEnter(Collider other)
    {
        sc.dialougeInst.getPlaybackState(out pbState);
        sc.NonLinearNum = funcNum;

        if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            Debug.Log("playDialogue");
            sc.NonLinearAudio();
            Debug.Log("destroyObject");
            Destroy(gameObject);


        }
        else
        {


        }




    }
   public void OnTriggerExit(Collider other)
    {
        //sc.NonLinearNum = funcNum;
        //if (funcNum == 7)
        {
            //if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                //sc.NonLinearAudio();
                //Destroy(gameObject);

            }
            //else
            {


            }

        }
    }
}
