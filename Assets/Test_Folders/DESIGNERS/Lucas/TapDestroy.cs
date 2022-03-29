using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private Camera camera = null;

    private Ray rayPointer;
    private RaycastHit rayHit;
    private string CollectableObject = "Collectable";
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        rayPointer = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayPointer, out rayHit))
        {
            if(rayHit.collider.gameObject.tag == "Collectable")
            Destroy(rayHit.transform.gameObject);
        }
    }
}
