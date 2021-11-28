using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card : MonoBehaviour
{
    //需要宝石数，获得复仇者数，获得绿宝石数（id>=70即获得绿宝石），获得牌色（1-5）
    //是否可选择（购买）
    public int id;//编号0-89,根据编号确定卡牌及动态加载图片
    public int score;//分数
    public int fcz;//复仇者
    public int color;//1-5，红橙黄蓝紫
    public Sprite image;//图片
    //花费宝石数组
    public int[] cost = { 0, 0, 0, 0, 0 };
    public int get7 = 0;//得到的绿宝石
    public int rank = 1;//等级

    public Card()
    {

    }

    public Card(int i,int c,int s,int f,int c1,int c2, int c3, int c4, int c5)//编号，颜色，分数，复仇者，花费
    {
        id = i;
        color = c;
        score = s;
        fcz = f;
        cost[0] = c1;
        cost[1] = c2;
        cost[2] = c3;
        cost[3] = c4;
        cost[4] = c5;
        if (i >= 40) rank = 2;
        if (i >= 70) rank = 3;
        if (rank==3) get7 = 1;//绿宝石
        i++;
        image = Resources.Load<Sprite>("Cards/M" + i);//图片
    }

}
