using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }
}
