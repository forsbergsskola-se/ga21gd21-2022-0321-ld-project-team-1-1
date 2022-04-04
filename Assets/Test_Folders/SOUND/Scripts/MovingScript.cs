using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.EventReference placeEventHere;

    private FMOD.Studio.EventInstance myinstance;

    public bool is3D = false;

    void Start()
    {
        myinstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);

        //should be in void update
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myinstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.W)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.A)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.S)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.D)) myinstance.start();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)) myinstance.start();
        else myinstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
