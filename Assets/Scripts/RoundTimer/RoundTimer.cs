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

   public string GetFormattedString()
   {
      int minutes = Mathf.FloorToInt(time / 60.0f);
      string minutesString = minutes.ToString("D2");
      int seconds = Mathf.FloorToInt(time % 60.0f);
      string secondsString = seconds.ToString("D2");
      
      return minutesString + ":" + secondsString;
   }
}
