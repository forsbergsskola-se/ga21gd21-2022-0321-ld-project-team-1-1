using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScrapingAudio : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 oldpos;
    private FMOD.Studio.EventInstance LoopInst;
    public FMODUnity.EventReference loopRef;
    private FMOD.Studio.PLAYBACK_STATE pbState;

    // Start is called before the first frame update
    void Start()
    {
        LoopInst = FMODUnity.RuntimeManager.CreateInstance(loopRef);
        pos = transform.position;
        oldpos = transform.position;
    }

    private void FixedUpdate()
    {
        LoopInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, GetComponent<Rigidbody>()));
        LoopInst.getPlaybackState(out pbState);

        if (pos != oldpos)
        {

                LoopInst.start();
            Debug.Log("playScraingsound");

        }
        else if (pos == oldpos && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            LoopInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        oldpos = pos;
        
    }

}
