using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapDestroy : MonoBehaviour
{
    [SerializeField] private Camera camera = null;

    private Ray rayPointer;
    private RaycastHit rayHit;
    private string CollectableObject = "Collectable";
    public float timer;
    public float holdDuration = 3f;
    
    public Text countText;
    private int count;

    //AudioRef
    public SoundController Gravitygun;

    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Gravitygun.GravitygunAudio();
            timer = Time.time;
        }
        else if (Input.GetMouseButton(0))
        {
            
            if (Time.time - timer > holdDuration)
            {
               
                
                //by making it positive inf, we won't subsequently run this code by accident,
                //since X - +inf = -inf, which is always less than holdDur
                timer = float.PositiveInfinity;
                Debug.Log("ShootRay");
                //perform our action
                ShootRay();
            }
        }
        else
        {
            Gravitygun.GravitygunAudioStop();
            timer = float.PositiveInfinity;
        }
    }

    public void ShootRay()
    {
        rayPointer = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayPointer, out rayHit))
        {
            
            if (rayHit.collider.gameObject.tag == "Collectable")
            {
                count = ++count;
                SetCountText();
                //Add audio ref loop
                

                Destroy(rayHit.transform.gameObject);
                //add release ref
                
            }
            
        }
    }
    
    void SetCountText()
    {
        countText.text = $"Collected resources: {count.ToString()}";
        // if (count >= 9)
        // {
        //     SceneManager.LoadScene(3);
        // }
    }
}
