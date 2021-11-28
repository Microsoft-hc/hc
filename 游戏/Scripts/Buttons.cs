using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Scriptscontrol sc;//ȫ�ֿ��ƽű�
    public Player p;//��ҽű�
    public ThisCard s;//���ƽű�

    public GameObject P2;//��ʼ����
    public GameObject SelectPlayerPage;//ѡ�����������

    public int Pnum;//
    public string k;//
    public GameObject S1;//
    public string T1;//

    public void Awake()
    {
        sc = GameObject.Find("Scriptscontrol").GetComponent<Scriptscontrol>();
        P2 = GameObject.Find("P2");
        SelectPlayerPage = GameObject.Find("SelectPlayerNum");
    }

    public void Update()
    {

    }

    public void Re_turn()//����
    {
        P2.SetActive(true);
    }

    public int needGem6Num()//��֪��Һ��ƣ�����Ҫ֧������ܱ�ʯ��
    {
        s = sc.scard.GetComponent<ThisCard>();//��̬��ÿ��ƽű�
        p = sc.PlayerList[sc.CurrentPlayer];//��̬�����ҽű�
        int num = 0;
        for (int i = 0; i < 5; i++) num += s.cost[i] > p.gems[i] + p.cards[i] ? s.cost[i] - p.gems[i] - p.cards[i] : 0;
        return num;
    }

    public void goumai()//������
    {
        if (!sc.scard) return;
        s = sc.scard.GetComponent<ThisCard>();//��̬��ÿ��ƽű�
        p = sc.PlayerList[sc.CurrentPlayer];//��̬�����ҽű�
        int n = needGem6Num();//��Ҫ֧������ܱ�ʯ��

        //������ѡ����ƴ��� and ��Ҫ֧������ܱ�ʯ��<=��ӵ����ܱ�ʯ��
        if (n <= p.gems[5])
        {
            //���֧��
            for(int i=0;i<5;i++)
            {
                //s.cost[0-4],p.gems[0-4],p.cards[0-4]if (card >= cost) ;else if (card + gem >= cost) ֧��cost - card;else ֧��gem��
                int k;
                if (p.cards[i] >= s.cost[i]) ;
                else if (p.cards[i] + p.gems[i] >= s.cost[i])
                {
                    k = s.cost[i] - p.cards[i];
                    p.gems[i] -= k;
                    sc.gems[i] += k;
                }
                else
                {
                    k = p.gems[i];
                    p.gems[i] = 0;
                    sc.gems[i] += k;
                }
            }
            p.gems[5] -= n;     sc.gems[5] += n;


            sc.scard.transform.SetParent(GameObject.Find("type"+s.color).transform);//���ƴ���������
            if (s.place == 1)
            {
                if (s.rank == 1 && sc.num1 > 0) sc.num1--;
                else if (s.rank == 2 && sc.num2 > 0) sc.num2--;
                else if (s.rank == 3 && sc.num3 > 0) sc.num3--;
            }
            else if (s.place == 2) p.saveCardNum--;
            s.place = 3;

            //��ҽ���//
            p.cards[s.color-1]++;
            p.score += s.score;
            p.fcz += s.fcz;
            p.gems[6] += s.get7;    sc.gems[6] -= s.get7;

            sc.isTurnOut = true;//�غϽ���
        }
        //��������֧�����豦ʯ���ƴ�������������һ�ö�Ӧ�����������������������ߣ��̱�ʯ�����غϽ���
    }

    public void baoliu()//������
    {
        if (!sc.scard) return;
        s = sc.scard.GetComponent<ThisCard>();//��̬��ÿ��ƽű�
        p = sc.PlayerList[sc.CurrentPlayer];//��̬�����ҽű�

        //������ѡ����ƴ��� and λ���ڹ����� and ��ұ���������<3
        if (s.place == 1 && p.saveCardNum < 3)
        {    
            sc.scard.transform.SetParent(GameObject.Find("precards").transform);//���ƴ��뱣����
            if (s.rank == 1 && sc.num1 > 0) sc.num1--;
            else if (s.rank == 2 && sc.num2 > 0) sc.num2--;
            else if (s.rank == 3 && sc.num3 > 0) sc.num3--;
            p.saveCardNum++;
            s.place = 2;

            //��ҽ���
            if(sc.gems[5]>0)
            {
                p.gems[5]++;
                sc.gems[5]--;
            }

            sc.isTurnOut = true;//�غϽ���
        }
        //�������һ����ܱ�ʯx1���ƴ��뱣�������غϽ���
    }

    public void btsg()//��ͬ3��
    {
        //public int[] sgems = { 0, 0, 0, 0, 0 };//�洢ѡ�еı�ʯ
        if (sc.snum == 3)
        {
            p = sc.PlayerList[sc.CurrentPlayer];//��̬�����ҽű�
            for (int i = 0; i < 5; i++) if (sc.sgems[i] == 1)
            {
                p.gems[i]++;
                sc.gems[i]--;
            }
            sc.isTurnOut = true;//�غϽ���
        }
    }

    public void tzlg()//ͬ������
    {
        if (sc.snum == 1)
        {
            p = sc.PlayerList[sc.CurrentPlayer];//��̬�����ҽű� 
            for (int i = 0; i < 5; i++) if (sc.sgems[i] == 1)
            {
                if (sc.gems[i] < 4) return;
                p.gems[i]+=2;
                sc.gems[i]-=2;
            }
            sc.isTurnOut = true;//�غϽ���
        }
    }


    public void SelectPlayerNum()//չʾѡ�����
    {
        SelectPlayerPage.SetActive(true);
    }

    public void SelectPlayerNumOver()//ȡ��ѡ�����
    {
        SelectPlayerPage.SetActive(false);
    }

    public void StartGame()//��ʼ��Ϸ(˳��ر�ѡ�����)
    {
        S1 = GameObject.Find("T1");
        //T1 = S1.GetComponent<Text>().text;
        //print("�˺�" + T1.text);
        SelectPlayerNumOver();
        P2.SetActive(false);
    }

    public void BackGameMenue(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Enter()//当鼠标在图标上时变大
    {
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }


    public void Exit()//恢复原始大小
    {
        transform.localScale = new Vector3(1.0f,1.0f,1.0f);
    }
}
