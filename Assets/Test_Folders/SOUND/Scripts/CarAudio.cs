using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    
    public FMODUnity.EventReference vehicleRef;
    private FMOD.Studio.EventInstance vehicleInst;
    FMOD.Studio.PARAMETER_ID myParam_ID;
    public Rigidbody rb;
    public GettingInAndOutOfCars engine;
    private FMOD.Studio.PLAYBACK_STATE state;


    // Start is called before the first frame update
    void Start()
    {
         vehicleInst = FMODUnity.RuntimeManager.CreateInstance(vehicleRef);
         FMOD.Studio.EventDescription myParam_EventDescription;
         vehicleInst.getDescription(out myParam_EventDescription);
         FMOD.Studio.PARAMETER_DESCRIPTION myParam_ParameterDescription;
         myParam_EventDescription.getParameterDescriptionByName("EnginePitch", out myParam_ParameterDescription);
         myParam_ID = myParam_ParameterDescription.id;

        

    }
    private void Update()
    {
        

        if (engine.ridingInCar == true)
        {
            Debug.Log("startcar");
            vehicleInst.getPlaybackState(out state);

            Debug.Log("rb.velocity" + rb.velocity.magnitude);
            vehicleInst.setParameterByID(myParam_ID, rb.velocity.magnitude);
            //vehicleInst.setParameterByName("EnginePitch", rb.velocity.magnitude);

            if (state != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
            {

                vehicleInst.start();


            }




        }
        else if (engine.ridingInCar == false)
        {
            Debug.Log("stopCar");
            vehicleInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        }


        
        
    }

}
