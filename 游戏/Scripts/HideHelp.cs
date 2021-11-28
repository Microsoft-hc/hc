using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHelp : MonoBehaviour
{
    GameObject k;

    public void Awake()
    {
        k = GameObject.Find("Help");
    }

    public void Click()
    {
        k.SetActive(false);
    }
}
