using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   public Transform lookAt;
   public float boundX = 0.15f;
   public float boundY = 0.05f;

   private void LateUpdate()
   {
      Vector3 delta = Vector3.zero;
      float deltaX = lookAt.position.x - transform.position.x;
      float deltaY = lookAt.position.y - transform.position.y;
      
      if (deltaX > boundX || deltaX < -boundX)
      {
         delta.x = (transform.position.x < lookAt.position.x) ? deltaX - boundX : deltaX + boundX;
      }
         
      if (deltaY > boundY || deltaY < -boundY)
      {
         delta.y = (transform.position.y < lookAt.position.y) ? deltaY - boundY : deltaY + boundY;
      }

      transform.position += new Vector3(delta.x, delta.y, 0);
   }
}
