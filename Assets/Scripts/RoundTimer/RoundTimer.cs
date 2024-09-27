using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : PausableMonoBehaviour
{
   private float time = 0.0f;

   private void Update()
   {
      if (IsPaused) return;
      time += Time.deltaTime;
   }

   public float GetTimeInSeconds()
   {
      return time;
   }
}
