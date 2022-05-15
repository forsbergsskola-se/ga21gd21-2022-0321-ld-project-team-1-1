using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform playerCheckPoint;
    [SerializeField] private Transform carCheckPoint;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform carPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
             playerPosition.position = playerCheckPoint.position;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            carPosition.position = carCheckPoint.position;
            carPosition.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
