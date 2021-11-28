using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re_turn : MonoBehaviour
{
    GameObject k;
    GameObject h;

    public void Awake()
    {
        k = GameObject.Find("GetCardControl");
        h = GameObject.Find("start");
    }

    public void Click()//·µ»Ø
    {
        k.SetActive(false);
        k.SetActive(true);
        h.SetActive(true);
    }
}
