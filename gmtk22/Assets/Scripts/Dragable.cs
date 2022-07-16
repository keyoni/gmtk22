using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Dragable : MonoBehaviour
{
   private Vector3 mouseStart;
   private Vector3 spriteStart;
   public bool isHeld = false;

   //private bool isOverDie = false;
   //public event Action Released;
   

   private void OnMouseDown()
   { 
      isHeld = true;
      mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      spriteStart = this.transform.localPosition ;
      
        
      }

   private void OnMouseDrag()
   {
      if (isHeld)
      {
         transform.localPosition = spriteStart + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStart);
         
      }
   }

   private void OnMouseUp()
   {
      //Released?.Invoke();
     // print("Dropped");
      isHeld = false;
     
   }

}
