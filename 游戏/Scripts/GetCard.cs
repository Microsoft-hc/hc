using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetCard : MonoBehaviour
{
    public int mode;//模式    (人机，人人，在线)=(0,1,2)
    public GameObject js;//结算菜单
    public GameObject sc;//存牌位置
    public int lastvalue;//上个牌花色     (无花色=-1)
    public int thisvalue;//当前牌花色
    public GameObject Getcard;//摸牌区
    public GameObject Putcard;//置牌区
    public Text getcard_num;//摸牌区文本
    public GameObject texterror;//在线对战未开发
    public GameObject cou0;//抽牌按钮0
    public GameObject cou1;//抽牌按钮1
    public GameObject chu0;//出牌按钮0
    public GameObject chu1;//出牌按钮1
    public int[] H;//摸牌序列
    public int sum;//剩余牌数
    public int a, b;//玩家手牌数

    public void Awake()//初始化
    {
        mode = -1;//默认无模式
        js = GameObject.Find("JS");
        sc = GameObject.Find("Scriptscontrol");
        lastvalue = thisvalue = -1;
        Getcard = GameObject.Find("Get_card");
        Putcard = GameObject.Find("Put_card");
        getcard_num = GameObject.Find("Get_card_num").GetComponent<Text>();
        texterror = GameObject.Find("TextError");
        cou0 = GameObject.Find("cou0");
        cou1 = GameObject.Find("cou1");
        chu0 = GameObject.Find("chu0");
        chu1 = GameObject.Find("chu1");
        GameObject.Find("Help").SetActive(false);
        
        
        
    }

    public void OnEnable()
    {
        sum = 52;
        a = b = 0;
        int i, j, k;//产生随机摸牌序列H
        for (i = 0; i < sum; i++) H[i] = i;
        for (i = 0; i < sum; i++)
        {
            j = Random.Range(0, sum);
            k = H[i];
            H[i] = H[j];
            H[j] = k;
        }

        js.SetActive(false);
        texterror.SetActive(false);
        cou0.SetActive(false);
        turn_change();
        clear();
    }

    public void Start()
    {
        
    }

    public void Update()//若为人机模式，当轮到玩家1时，抽牌或摸牌
    {
        if (mode == 0 && cou1.activeSelf == true)//条件: 人机模式，玩家1回合
        {
            cou1.SetActive(false);//cou1不显示，避免重复执行
            chu1.SetActive(false);
            Invoke("AI", 0.65f);//等待0.65秒，执行接下来的操作
        }
    }

    public void AI()
    {
        if (b == 0) Get_Card();//没牌就抽
        else//有牌就出
        {
            int kk = 0;

            foreach (Transform child in GameObject.Find("1cards").transform)//从玩家1手牌中找牌
            {
                foreach (Transform cc in child)
                {
                    if (cc)
                    {
                        kk = 1;
                        sc.GetComponent<Scriptscontrol>().scard = cc.gameObject;//更改选中的卡牌
                    }
                    if (kk == 1) break;//找到第一张牌后，跳出循环
                }
                if (kk == 1) break;
            }
            Set_Card();
        }
    }

    public void Get_Card()//玩家摸牌，即按序列生成一张牌，并移动到置牌区(根据按钮是否显示判断当前玩家)
    {
        if(sum>0)//条件:剩余牌数>0
        {
            //摸牌
            GameObject card = Instantiate(Resources.Load("Card")) as GameObject;//生成不重复随机牌
            card.transform.SetParent(Putcard.transform);//放入置牌区
            card.transform.localScale = new Vector3(1, 1, 1);
            card.GetComponent<ThisCard>().thisId = H[--sum];
            card.name = "Card" + H[sum];

            //判定
            lastvalue = thisvalue;
            thisvalue = card.GetComponent<ThisCard>().thisId / 13;
            if (lastvalue == thisvalue) clear_put();//若花色相同，将置牌区的所有牌分给当前玩家，并清空花色缓存

            //回合切换
            turn_change();
        }
    }

    public void clear()//清除界面的卡牌
    {
        Transform c0 = GameObject.Find("0cards").transform;//玩家0
        foreach(Transform type in c0)
        {
            foreach(Transform card in type)
            {
                Destroy(card.gameObject);
            }
        }

        Transform c1 = GameObject.Find("1cards").transform;//玩家1
        foreach (Transform type in c1)
        {
            foreach (Transform card in type)
            {
                Destroy(card.gameObject);
            }
        }

        foreach (Transform card in Putcard.transform)
        {
            Destroy(card.gameObject);
        }
    }

    public void Set_Card()//玩家出牌，即将最后一次选中的手牌，移动到置牌区
    {
        GameObject s = sc.GetComponent<Scriptscontrol>().scard;//s为保存的卡牌
        int p = 1;
        if (cou0.activeSelf) p = 0;
        if ((s) && (p == s.GetComponent<ThisCard>().place))//条件:选中手牌存在 && 当前玩家==手牌所属玩家
        {
            //出牌
            s.transform.SetParent(Putcard.transform);//放入置牌区
            s.GetComponent<ThisCard>().place = 2;
            if (p == 0) a--;
            else b--;//手牌数减少


            //判定
            lastvalue = thisvalue;
            thisvalue = s.GetComponent<ThisCard>().thisId / 13;
            if (lastvalue == thisvalue) clear_put();//若花色相同，将置牌区的所有牌分给当前玩家，并清空花色缓存

            //回合切换
            turn_change();
        }
    }

    public void clear_put()//吃牌
    {
        List<Transform> children = new List<Transform>();//存储置牌区卡牌
        int p = 1;//当前玩家
        if (cou0.activeSelf) p = 0;
        foreach (Transform child in Putcard.transform) children.Add(child);
        foreach (Transform card in children)
        {
            card.gameObject.GetComponent<ThisCard>().place = p;//设置卡牌所属玩家
            card.SetParent(GameObject.Find(p + "type" + card.GetComponent<ThisCard>().thisId / 13).transform);
            if (p==0) a++;
            else b++;//手牌数增加
        }
        lastvalue = thisvalue = -1;
    }

    public void turn_change()//回合切换(根据cou0是否显示)
    {
        if (cou0.activeSelf)
        {
            cou1.SetActive(true);
            cou0.SetActive(false);
            chu1.SetActive(true);
            chu0.SetActive(false);
        }
        else
        {
            cou0.SetActive(true);
            cou1.SetActive(false);
            chu0.SetActive(true);
            chu1.SetActive(false);
        }


        if (sc.GetComponent<Scriptscontrol>().scard) sc.GetComponent<Scriptscontrol>().scard.transform.localScale = new Vector3(1, 1, 1);//之前选中卡牌缩小
        sc.GetComponent<Scriptscontrol>().scard = null;//清空选卡缓存
        GameObject.Find("0Text").GetComponent<Text>().text = "牌数: " + a;//更新玩家0牌数
        GameObject.Find("1Text").GetComponent<Text>().text = "牌数: " + b;//更新玩家1牌数
        getcard_num.text = "牌数:" + sum;//更新剩余牌数
        if (sum == 0) //结算界面
        {
            cou0.SetActive(false);
            cou1.SetActive(false);
            chu0.SetActive(false);
            chu1.SetActive(false);
            Getcard.SetActive(false);
            js.SetActive(true);
            js.transform.Find("Text3").GetComponent<Text>().text = "p1: " + a + "    " + "p2: " + b;
            string k;
            if (a == b) k = "平局！";
            else if (a > b) k = "Player2 获胜";
            else k = "Player1 获胜";
            js.transform.Find("Text4").GetComponent<Text>().text = k;
        }
    }

    public void pc()//人机模式
    {
        mode = 0;
        GameObject.Find("start").SetActive(false);
    }

    public void pp()//人人模式
    {
        mode = 1;
        GameObject.Find("start").SetActive(false);
    }

    public void ol()//在线模式(未开放)
    {
        mode = 2;
        texterror.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }
}