using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.tag == "Player")
      {
         Destroy(other.gameObject);
      }
   }
}
