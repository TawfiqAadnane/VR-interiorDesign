using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazeableobject : MonoBehaviour
{
    // Start is called before the first frame update
   public virtual void OnGazeEnter(RaycastHit hitInfo)
   {
        Debug.Log("Gaze entred on "+ gameObject.name);

   }

   public virtual void OnGaze(RaycastHit hitInfo)
   {
        Debug.Log("Gaze hold on"+ gameObject.name);
   }

   public virtual void OnGazeExit()
   {
        Debug.Log("Gaze Exited on:"+ gameObject.name);
   }

   public virtual void OnPress(RaycastHit hitInfo)
   {

   }

   public virtual void OnHold(RaycastHit hitInfo)
   {

   }

   public virtual void OnRelease(RaycastHit hitInfo)
   {

   }
}
