using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    //public SoundController loadsound;
    public FMODUnity.EventReference crystalAmbienceRef;
    private FMOD.Studio.EventInstance crystalAmbienceInst;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "NewPlayerFPS")
        {
            Debug.Log("playCrystalAmb");
            crystalAmbienceInst = FMODUnity.RuntimeManager.CreateInstance(crystalAmbienceRef);
            crystalAmbienceInst.start();
            //loadsound.CrystalAmbAudio();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if ((other.name == "NewPlayerFPS" || (other.name == "SpaceVehicle")))
        {
            Debug.Log("StopCrystalAmb");
            crystalAmbienceInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            crystalAmbienceInst.release();
            //loadsound.CrystalAmbStop();
        }
    }
}
