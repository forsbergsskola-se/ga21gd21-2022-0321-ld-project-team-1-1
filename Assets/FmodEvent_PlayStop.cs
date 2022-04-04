using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodEvent_PlayStop : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.EventReference placeEventHere;

    private FMOD.Studio.EventInstance myinstance;

    void Start()
    {
        myinstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) myinstance.start();
        if (Input.GetKeyDown(KeyCode.A)) myinstance.start();
        if (Input.GetKeyDown(KeyCode.S)) myinstance.start();
        if (Input.GetKeyDown(KeyCode.D)) myinstance.start();

    }
}
