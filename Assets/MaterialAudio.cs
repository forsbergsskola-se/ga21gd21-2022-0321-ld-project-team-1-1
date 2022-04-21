using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAudio : MonoBehaviour
{
    public MovingScript footsteps;
    public int material = 1;

    private void OnTriggerEnter(Collider other)
    {
     if (other.name == "NewPlayerFPS")
        footsteps.ChangeMaterial(material);
        Debug.Log("iceSteps");
    }
    private void OnTriggerExit(Collider other)
    {
     if (other.name == "NewPlayerFPS")
            footsteps.ChangeMaterial(0);
        Debug.Log("Snowsteps");
    }

}


