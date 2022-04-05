using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private Camera camera = null;

    private Ray rayPointer;
    private RaycastHit rayHit;
    private string CollectableObject = "Collectable";
    public float timer;
    public float holdDuration = 3f;
    
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
            timer = Time.time;
        }
        else if (Input.GetMouseButton(0))
        {
            if (Time.time - timer > holdDuration)
            {
                //by making it positive inf, we won't subsequently run this code by accident,
                //since X - +inf = -inf, which is always less than holdDur
                timer = float.PositiveInfinity;
                
                //perform our action
                ShootRay();
            }
        }
        else
        {
            timer = float.PositiveInfinity;
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
