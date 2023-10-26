using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazSystem : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject reticle;

    public Color inactiveReticleColor = Color.gray;

    public Color activeReticleColor = Color.blue;

    private Gazeableobject currentGazeObject;

    private Gazeableobject currentSelectedObject;

    private RaycastHit lastHit;

    void Start()
    {
        SetReticuleColor(inactiveReticleColor);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessGaze();
        CheckForInput(lastHit);
    }

    public void ProcessGaze ()
    {
        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);
        
        if (Physics.Raycast(raycastRay, out hitInfo))
        {
        // Do something to the object 

        //check the object if interactable

        //Get the gameobject from the hitInfo
        GameObject hitObj = hitInfo.collider.gameObject;
        //Get the GazeableObject from the hit object

        Gazeableobject gazeObj = hitObj.GetComponentInParent<Gazeableobject>();

        

        //Object has a GazeableObject Component
        if (gazeObj != null)
        {
            //Object we're looking at is different
            if (gazeObj != currentGazeObject)
            {
                ClearCurrentObject();
                currentGazeObject = gazeObj;
                currentGazeObject.OnGazeEnter(hitInfo);
                SetReticuleColor(activeReticleColor);
            } 
            else
            {
                currentGazeObject.OnGaze(hitInfo);
            }
        }
        else
        {
            ClearCurrentObject();
        }

        lastHit = hitInfo;
        //check if the object is new object (first time looking)
        


        //set the reticule color
        }


    }

    private void SetReticuleColor(Color reticuleColor)
    {
        //set color to reticule
        reticle.GetComponent<Renderer>().material.SetColor("_Color",reticuleColor);
    }

    private void CheckForInput(RaycastHit hitInfo)
    {
        //check for down
        if (Input.GetMouseButtonDown(0) && currentGazeObject != null)
        {
            currentSelectedObject = currentGazeObject;
            currentSelectedObject.OnPress(hitInfo);
        }
        else if(Input.GetMouseButton(0) && currentGazeObject != null)
        {
            currentSelectedObject.OnHold(hitInfo);
        }
        else if (Input.GetMouseButtonUp(0) && currentGazeObject != null)
        {
            currentSelectedObject.OnRelease(hitInfo);
            currentSelectedObject = null;
        }

        // check for hold

        //check for release
    }

    private void ClearCurrentObject()
    {
        if(currentGazeObject != null)
        {
            currentGazeObject.OnGazeExit();
            SetReticuleColor(inactiveReticleColor);
            currentGazeObject = null;
        
        }
    }
}
