using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public FMODUnity.EventReference boxCollisionRef;
    private FMOD.Studio.EventInstance boxCollisionInst;
    public float impactThresh = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > impactThresh)
        {
            Debug.Log("Play Impact Sound_1 " + collision.relativeVelocity.magnitude);
            boxCollisionInst = FMODUnity.RuntimeManager.CreateInstance(boxCollisionRef);
            boxCollisionInst.setParameterByName("ImpactForce", collision.relativeVelocity.magnitude);
            boxCollisionInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            boxCollisionInst.start();
            boxCollisionInst.release();
        }
        else if (collision.relativeVelocity.magnitude < impactThresh)
        {
            Debug.Log("Play Impact Sound_10 " + collision.relativeVelocity.magnitude);
            boxCollisionInst = FMODUnity.RuntimeManager.CreateInstance(boxCollisionRef);
            boxCollisionInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            boxCollisionInst.start();
            boxCollisionInst.release();
        }



    }
}
