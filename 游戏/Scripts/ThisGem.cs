using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//�¼�ϵͳ

public class ThisGem : MonoBehaviour
{
    public Scriptscontrol sc;//ȫ�ֿ��ƽű�
    public int id=0;//0-4:��Ȼ�����

    public void Awake()
    {
        sc = GameObject.Find("Scriptscontrol").GetComponent<Scriptscontrol>();
    }

    public void OnClick()
    {
        if (sc.gems[id] == 0) return;//��ʯΪ0����ѡ 
        if (sc.sgems[id] == 0)//δ��ѡ��
        {
            sc.sgems[id] = 1;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sc.snum++;
        }
        else//�ѱ�ѡ��
        {
            sc.sgems[id] = 0;
            transform.localScale = new Vector3(1f, 1f, 1f);
            sc.snum--;
        }
    }
}
