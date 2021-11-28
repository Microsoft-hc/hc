using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//事件系统

public class ThisGem : MonoBehaviour
{
    public Scriptscontrol sc;//全局控制脚本
    public int id=0;//0-4:红橙黄蓝紫

    public void Awake()
    {
        sc = GameObject.Find("Scriptscontrol").GetComponent<Scriptscontrol>();
    }

    public void OnClick()
    {
        if (sc.gems[id] == 0) return;//宝石为0不可选 
        if (sc.sgems[id] == 0)//未被选中
        {
            sc.sgems[id] = 1;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sc.snum++;
        }
        else//已被选中
        {
            sc.sgems[id] = 0;
            transform.localScale = new Vector3(1f, 1f, 1f);
            sc.snum--;
        }
    }
}
