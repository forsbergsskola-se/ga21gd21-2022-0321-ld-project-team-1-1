using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAudio : MonoBehaviour
{
    public FMODUnity.EventReference ShrinkingRef;
    private FMOD.Studio.EventInstance Shrinking�nst;
    public void OnTriggerEnter(Collider other)
    {
        Shrinking�nst = FMODUnity.RuntimeManager.CreateInstance(ShrinkingRef);
        Debug.Log("shrinkingUpgradeAudio");
        Shrinking�nst.start();
        Shrinking�nst.release();
    }












}
