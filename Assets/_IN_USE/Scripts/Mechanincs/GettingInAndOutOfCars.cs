using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class GettingInAndOutOfCars : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] FreeLookCam mCamera = null;
    
    [Header("Human")]
    [SerializeField] private GameObject human = null;

    [SerializeField] private GameObject ThirdPersonCamera = null;

    [Header("Spawn distance from car")]
    [SerializeField] private float closeDistance;

    [SerializeField] public GameObject RightCarDoor;
    [SerializeField] public GameObject LeftCarDoor;
    [SerializeField] private Vector3 SpawnDistance;
    
    [Space, Header("Car Stuff")]
    [SerializeField] private GameObject car = null;
    [SerializeField] CarUserControl carController = null;
    [SerializeField] private CarController carEngine = null;
    [SerializeField] public Rigidbody carBody;
    public float steeringCar = 0;
    public float accelerateCar = 0;
    public float brakeCar = 1;
    public float handBrakeCar = 1;

    [Header("Input")]
    [SerializeField] private KeyCode enterExitKey = KeyCode.E;

    [Header("UI")]
    [SerializeField] private Image pointer;
    [SerializeField] private Image bar;

    bool inCar = false;
    public bool ridingInCar = false;



    private void Start()
    {
        //inCar = car.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((enterExitKey)))
        {
            if (inCar)
            {
                GetOutOfCar();
                // BrakeCar();
                ridingInCar = false;
            }
            else if (Vector3.Distance(RightCarDoor.transform.position, human.transform.position) < closeDistance) //if out of car
            {
                GetIntoCar();
                ridingInCar = true;
            }
            else if (Vector3.Distance(LeftCarDoor.transform.position, human.transform.position) < closeDistance) //if out of car
            {
                GetIntoCar();
                ridingInCar = true;
            }
        }
    }

    void GetOutOfCar()
    {
        // brakeCar = 1;
        // handBrakeCar = 1;
        inCar = false;
        
        human.SetActive((true));
        
        //activate HUD
        pointer.enabled = true;
        bar.enabled = true;

        ThirdPersonCamera.SetActive((false));
        
        human.transform.position = LeftCarDoor.transform.position + SpawnDistance;

        mCamera.SetTarget((human.transform));

        carController.enabled = false;

        //carEngine.enabled = false;

        //car.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        
        //carEngine.Move(steeringCar,accelerateCar,brakeCar,handBrakeCar);

        carBody.isKinematic = true;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void GetIntoCar()
    {
        // brakeCar = 0;
        // handBrakeCar = 0;
        inCar = true;
        
        human.SetActive((false));
        
        //Deactivate HUD
        pointer.enabled = false;
        bar.enabled = false;
        
        ThirdPersonCamera.SetActive((true));
        
        mCamera.SetTarget(car.transform);

        carController.enabled = true;

        //carEngine.enabled = true;

        carBody.isKinematic = false;

    }

    // // void BrakeCar()
    // {
    //     carEngine.Move(steeringCar,accelerateCar,brakeCar,handBrakeCar);
    // }                      
}

