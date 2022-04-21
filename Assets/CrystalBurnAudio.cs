using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBurnAudio : MonoBehaviour
{


    public FMODUnity.EventReference crystalburnRef;
    private FMOD.Studio.EventInstance crystalburnInst;
    // Start is called before the first frame update
    void Start()
    {
        crystalburnInst = FMODUnity.RuntimeManager.CreateInstance(crystalburnRef);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(crystalburnInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CrystalBurnStart()
    {
        crystalburnInst.start();
    }
    public void CrystalBurnStop()
    {
        crystalburnInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}

