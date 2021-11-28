using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHelp : MonoBehaviour
{
    GameObject k;

    public void Awake()
    {
        k = GameObject.Find("Help");
    }

    public void Click()
    {
        k.SetActive(true);
    }
}
