using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour
{
    public abstract void Pause();
    public abstract void UnPause();
}
