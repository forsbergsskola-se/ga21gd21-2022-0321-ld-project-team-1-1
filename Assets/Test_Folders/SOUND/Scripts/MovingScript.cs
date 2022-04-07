using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public GameObject mainCam;
    public float footThresh = 0.1f;

    // Start is called before the first frame update
    public FMODUnity.EventReference foot_EvRef;
    private bool isMoving = false;
    private int footDir = -1;

    private FMOD.Studio.EventInstance foot_EvInst;

    public bool is3D = false;

    void Start()
    {
        foot_EvInst = FMODUnity.RuntimeManager.CreateInstance(foot_EvRef);

        //should be in void update
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(foot_EvInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.W)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.A)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.S)) myinstance.start();
        //if (Input.GetKeyDown(KeyCode.D)) myinstance.start();

        //if audio is loop
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)) isMoving = true;
        else isMoving = true;

        //if (Input.GetKeyDown(KeyCode.LeftShift)) IsRunning = true; 
        float angleBuffer = mainCam.transform.localEulerAngles.z;
        if (Mathf.Abs(angleBuffer) > footThresh)
        {
            float convertedAngle = 0f;
            if (angleBuffer > 357) convertedAngle = angleBuffer - 360;
            else convertedAngle = angleBuffer;

            Debug.Log("val step " + Mathf.Sign(convertedAngle));
            if(footDir == Mathf.Sign(convertedAngle))
            {
                Debug.Log("TAKE STEP");
                FMOD.Studio.EventInstance tmpFoot = FMODUnity.RuntimeManager.CreateInstance(foot_EvRef);
                tmpFoot.start();
                tmpFoot.release();
                footDir *= -1;
            }

            
        }

    }

    public void Footsteps()
    {
        Debug.Log("footstep");
    }
}
