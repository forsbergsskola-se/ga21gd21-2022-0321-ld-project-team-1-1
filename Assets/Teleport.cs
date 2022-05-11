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
        if (Input.GetKeyDown(KeyCode.F))
        {
             playerPosition.position = playerCheckPoint.position;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            carPosition.position = carCheckPoint.position;
        }
    }
}
