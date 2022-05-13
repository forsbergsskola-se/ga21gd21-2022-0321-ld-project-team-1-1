using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAudio : MonoBehaviour
{
    public FMODUnity.EventReference ShrinkingRef;
    private FMOD.Studio.EventInstance ShrinkingÍnst;
    public void OnTriggerEnter(Collider other)
    {
        ShrinkingÍnst = FMODUnity.RuntimeManager.CreateInstance(ShrinkingRef);
        Debug.Log("shrinkingUpgradeAudio");
        ShrinkingÍnst.start();
        ShrinkingÍnst.release();
    }












}
