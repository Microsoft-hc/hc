using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scriptscontrol : MonoBehaviour//全局管理
{
    //卡牌信息
    public GameObject Get_Cards;//抽牌堆对象
    public GameObject scard = null;//存储选中的卡牌
    public int sum1 = 40, sum2 = 30, sum3 = 20;//三种等级牌的总数量
    public int num1, num2, num3;//三种等级牌的剩余量
    public int[] H1,H2,H3;//三种等级牌的摸牌序列

    //玩家信息
    //p = GameObject.Find(PlayerList[i]).GetComponent<Player>();//动态获得玩家脚本
    public int PlayerSum;//玩家总数
    public Player[] PlayerList;//玩家列表
    public GameObject[] PT;//玩家基础信息表
    public int CurrentPlayer = 0;//当前玩家
    public bool isTurnOut = false;//判断回合是否结束
    public bool isGameOver = false;//判断游戏是否结束
    public int winPlayer = 0;//获胜玩家编号

    //宝石信息
    public GameObject Get_Gems;//宝石区对象
    public int[] sgems = { 0, 0, 0, 0, 0 };//存储选中的宝石
    public int snum = 0;//存储选中宝石的数量
    public int[] gems = { 7, 7, 7, 7, 7, 5, 99};

    //其他
    public GameObject JS;
    public GameObject myself;

    public void Awake()
    {
        Get_Gems = GameObject.Find("Get_Gems");
        Get_Cards = GameObject.Find("Get_Cards");
        PlayerSum = StaticVarious.playernum;
    }

    public void Start()
    {
        for (int i = 0; i < PlayerSum; i++)
        {
            PT[i].SetActive(true);
        }
    }

    public void Update()
    {
        //若回合结束，切换回合
        if (isTurnOut)
        {
            isTurnOut = false;
            TurnChange();
        }

        //显示当前玩家主界面;
        //显示其余玩家基本信息;
    }

    public void OnEnable()
    {
        infset();
        createH123();
        H123toGetCard();


        //clear();
    }


    public void TurnChange()//切换回合
    {
        //全局更新
        UpdateGems();
        UpdateCards();
        UpdatePText();
        //选中卡牌清空
        if (scard)
        {
            scard.transform.localScale = new Vector3(1, 1, 1);
            scard = null;
        }
        //选中宝石清空
        for (int i = 0; i < 5; i++)
        {
            Get_Gems.transform.Find("gem" + (i + 1)).localScale = new Vector3(1f, 1f, 1f);
            sgems[i] = 0;
        }
        snum = 0;




        //玩家更新
        Player p = PlayerList[CurrentPlayer];//动态获得当前玩家脚本
        //刷新当前玩家宝石数
        p.gemnum = 0;
        foreach (int i in p.gems) p.gemnum += i;
        for(; p.gemnum>10; )//丢宝石（目前随机丢，之后改为玩家选择）
        {
            int i = Random.Range(0,5);
            if(p.gems[i]>0)
            {
                p.gems[i]--;
                gems[i]++;
                p.gemnum--;
            }
        }
        //判断板块




        //玩家切换(每切换一轮判定游戏是否结束)
        p.gameObject.SetActive(false);
        CurrentPlayer += 1;

        if (CurrentPlayer == PlayerSum)//每个大回合判断游戏是否结束
        {
                /*//玩家信息
                public int PlayerSum = 1;//玩家总数
                public string[] PlayerList = { "Player1" };//玩家名字列表
                public int CurrentPlayer = 0;//当前玩家
                public bool isTurnOut = false;//判断回合是否结束
                public bool isGameOver = false;//判断游戏是否结束*/
            for(int i = PlayerSum - 1; i >= 0; i--)
            {
                p = PlayerList[i];//动态获得玩家脚本
                if (p.score >= 16 && p.gems[6] >= 1 && p.cards[0]>=1 && p.cards[1] >= 1 && p.cards[2] >= 1 && p.cards[3] >= 1 && p.cards[4] >= 1)//胜利条件
                {
                    isGameOver = true;
                    winPlayer = i;
                }
                if(isGameOver)
                {
                    JS.SetActive(true);
                    for (int j = 0; j < PlayerSum; j++)
                    {
                        p = PlayerList[j];//动态获得玩家脚本
                        JS.transform.Find("W" + (j + 1)).GetComponent<Text>().text = "" + p.pname+":"+p.score+"分";
                    }
                    JS.transform.Find("Text2").GetComponent<Text>().text = "恭喜" + PlayerList[winPlayer].pname + "获胜";

                    //若游戏结束，隐藏sc及按钮
                    isGameOver = false;
                    GameObject.Find("Buttons").SetActive(false);
                    myself.SetActive(false);
                    return;

                }
            }
        }

        CurrentPlayer %= PlayerSum;
        PlayerList[CurrentPlayer].gameObject.SetActive(true);
    }





    public void infset()
    {
        num1 = 36;
        num2 = 26;
        num3 = 16;
    }

    public void createH123()
    {
        int i, j, k;
        //产生随机摸牌序列H1
        for (i = 0; i < sum1; i++) H1[i] = i;
        for (i = 0; i < sum1; i++)
        {
            j = Random.Range(0, sum1);
            k = H1[i];
            H1[i] = H1[j];
            H1[j] = k;
        }
        //产生随机摸牌序列H2
        for (i = 0; i < sum2; i++) H2[i] = i + sum1;
        for (i = 0; i < sum2; i++)
        {
            j = Random.Range(0, sum2);
            k = H2[i];
            H2[i] = H2[j];
            H2[j] = k;
        }
        //产生随机摸牌序列H3
        for (i = 0; i < sum3; i++) H3[i] = i + sum1 + sum2;
        for (i = 0; i < sum3; i++)
        {
            j = Random.Range(0, sum3);
            k = H3[i];
            H3[i] = H3[j];
            H3[j] = k;
        }
    }//产生随机摸牌序列H123

    public void H123toGetCard()//将H123实例化为游戏对象，并放入购牌区
    {
        //H1实例化
        for (int i = 0; i < sum1; i++)
        {
            GameObject card = Instantiate(Resources.Load("Fcard")) as GameObject;//生成不重复随机牌
            card.transform.SetParent(GameObject.Find("Get_Card1").transform);//放入购牌区
            card.GetComponent<ThisCard>().thisId = H1[i];
            card.name = "Card" + H1[i];
        }
        //H2实例化
        for (int i = 0; i < sum2; i++)
        {
            GameObject card = Instantiate(Resources.Load("Fcard")) as GameObject;//生成不重复随机牌
            card.transform.SetParent(GameObject.Find("Get_Card2").transform);//放入购牌区
            card.GetComponent<ThisCard>().thisId = H2[i];
            card.name = "Card" + H2[i];
        }
        //H3实例化
        for (int i = 0; i < sum3; i++)
        {
            GameObject card = Instantiate(Resources.Load("Fcard")) as GameObject;//生成不重复随机牌
            card.transform.SetParent(GameObject.Find("Get_Card3").transform);//放入购牌区
            card.GetComponent<ThisCard>().thisId = H3[i];
            card.name = "Card" + H3[i];
        }
    }

    public void UpdateGems()//更新宝石区
    {
        for (int i = 0; i < 6; i++) Get_Gems.transform.Find("gem" + (i + 1)).Find("Text").GetComponent<Text>().text = ""+ gems[i];
    }

    public void UpdateCards()//更新抽牌堆
    {
        Get_Cards.transform.Find("cardback1").Find("Text").GetComponent<Text>().text = "" + num1;
        Get_Cards.transform.Find("cardback2").Find("Text").GetComponent<Text>().text = "" + num2;
        Get_Cards.transform.Find("cardback3").Find("Text").GetComponent<Text>().text = "" + num3;
    }

    public void UpdatePText()//刷新玩家信息表
    {
        for(int i=0;i<PlayerSum;i++)
        {
            PT[i].transform.Find("Text1").gameObject.GetComponent<Text>().text = "玩家" + (i + 1) + ": ";
            PT[i].transform.Find("Text2").gameObject.GetComponent<Text>().text = "币 " + PlayerList[i].gems[0] + "   " + PlayerList[i].gems[1] + "   " + PlayerList[i].gems[2]
                + "   " + PlayerList[i].gems[3] + "   " + PlayerList[i].gems[4] + " | " + PlayerList[i].gems[5] + "   " + PlayerList[i].gems[6] + " |\n牌 "
                + PlayerList[i].cards[0] + "   " + PlayerList[i].cards[1] + "   " + PlayerList[i].cards[2] + "   " + PlayerList[i].cards[3] + "   " + PlayerList[i].cards[4] + " |         |";
            PT[i].transform.Find("Text3").gameObject.GetComponent<Text>().text = "" + PlayerList[i].score;
            PT[i].transform.Find("Text4").gameObject.GetComponent<Text>().text = "" + PlayerList[i].fcz;
        }
    }
}
