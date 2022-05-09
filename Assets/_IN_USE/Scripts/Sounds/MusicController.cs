using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    
    public FMODUnity.EventReference musicEvRef;
    private FMOD.Studio.EventInstance musicEvInst;

    void Start()
    {
       musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicEvRef);
       musicEvInst.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMusicProgress(int _val)
    {
        musicEvInst.setParameterByName("Progress", _val);
    }


         
}
