using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public Scriptscontrol sc;//全局控制脚本
    public Card thisCard = new Card();//根据thisId获取数据库中对应的卡牌
    public int thisId;

    public Image thatImage;
    public int id;//编号0-89,根据编号确定卡牌及动态加载图片
    public int score;//分数
    public int fcz;//复仇者
    public int color;//1-5，红橙黄蓝紫
    public int[] cost = { 0, 0, 0, 0, 0 };
    public int get7;//得到的绿宝石
    public int rank;//等级

    public int place = 1;//购牌区,保留区,手牌: 1,2,3

    void Awake()
    {
        sc = GameObject.Find("Scriptscontrol").GetComponent<Scriptscontrol>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        genxin();
    }

    public void OnClick()
    {
        if (place == 3) return;
        if (sc.scard) sc.scard.transform.localScale = new Vector3(1, 1, 1);//之前选中卡牌缩小
        if (this.gameObject == sc.scard)
        {
            sc.scard = null;
            return;
        }
        transform.localScale = new Vector3(1.3f, 1.3f, 1.2f);//当前选中卡牌放大
        sc.scard = transform.gameObject;//更改选中的卡牌
    }

    public void genxin()//更新卡(静态)属性与UI
    {
        thisCard = CardDataBase.cardlist[thisId];//连接卡牌数据库
        
        thatImage.sprite = thisCard.image;
        id = thisCard.id;
        color = thisCard.color;
        score = thisCard.score;
        fcz = thisCard.fcz;
        cost[0] = thisCard.cost[0];
        cost[1] = thisCard.cost[1];
        cost[2] = thisCard.cost[2];
        cost[3] = thisCard.cost[3];
        cost[4] = thisCard.cost[4];
        rank = thisCard.rank;
        get7 = thisCard.get7;
    }
}
