using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject Texts;
    public Scriptscontrol sc;

    public int score = 0;//分数
    public int gemnum = 0;//当前宝石数
    public int[] gems = { 0, 0, 0, 0, 0, 0, 0 };//宝石数组: 红橙黄蓝紫+盾+绿
    public int[] cards = { 0, 0, 0, 0, 0 };//牌数组: 红橙黄蓝紫
    public int fcz = 0;//复仇者
    public int saveCardNum = 0;

    public string pname;
    public int id;

    public void Awake()
    {

    }

    public void Update()
    {
        Texts.transform.Find("Name").GetComponent<Text>().text = ""+pname;
        Texts.transform.Find("Inf").GetComponent<Text>().text = "分数:"+score.ToString()+"/16\n复仇者: "+fcz+"\n宝石数: "+gemnum+" / 10";
        Texts.transform.Find("Cardnum").GetComponent<Text>().text = "牌数  "+cards[0]+ "  	    		" + cards[1] + "  		    	" + cards[2] + 
            "  		    	" + cards[3] + "  	    		" + cards[4];
        Texts.transform.Find("Gemnum").GetComponent<Text>().text = "宝石  " + gems[0] + "  	    		" + gems[1] + "  		    	" + gems[2] +
            "  		    	" + gems[3] + "  	    		" + gems[4] + "  	    		" + gems[5] + "  	    		" + gems[6];
    }
}
