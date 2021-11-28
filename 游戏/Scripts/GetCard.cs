using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetCard : MonoBehaviour
{
    public int mode;//ģʽ    (�˻������ˣ�����)=(0,1,2)
    public GameObject js;//����˵�
    public GameObject sc;//����λ��
    public int lastvalue;//�ϸ��ƻ�ɫ     (�޻�ɫ=-1)
    public int thisvalue;//��ǰ�ƻ�ɫ
    public GameObject Getcard;//������
    public GameObject Putcard;//������
    public Text getcard_num;//�������ı�
    public GameObject texterror;//���߶�սδ����
    public GameObject cou0;//���ư�ť0
    public GameObject cou1;//���ư�ť1
    public GameObject chu0;//���ư�ť0
    public GameObject chu1;//���ư�ť1
    public int[] H;//��������
    public int sum;//ʣ������
    public int a, b;//���������

    public void Awake()//��ʼ��
    {
        mode = -1;//Ĭ����ģʽ
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
        int i, j, k;//���������������H
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

    public void Update()//��Ϊ�˻�ģʽ�����ֵ����1ʱ�����ƻ�����
    {
        if (mode == 0 && cou1.activeSelf == true)//����: �˻�ģʽ�����1�غ�
        {
            cou1.SetActive(false);//cou1����ʾ�������ظ�ִ��
            chu1.SetActive(false);
            Invoke("AI", 0.65f);//�ȴ�0.65�룬ִ�н������Ĳ���
        }
    }

    public void AI()
    {
        if (b == 0) Get_Card();//û�ƾͳ�
        else//���ƾͳ�
        {
            int kk = 0;

            foreach (Transform child in GameObject.Find("1cards").transform)//�����1����������
            {
                foreach (Transform cc in child)
                {
                    if (cc)
                    {
                        kk = 1;
                        sc.GetComponent<Scriptscontrol>().scard = cc.gameObject;//����ѡ�еĿ���
                    }
                    if (kk == 1) break;//�ҵ���һ���ƺ�����ѭ��
                }
                if (kk == 1) break;
            }
            Set_Card();
        }
    }

    public void Get_Card()//������ƣ�������������һ���ƣ����ƶ���������(���ݰ�ť�Ƿ���ʾ�жϵ�ǰ���)
    {
        if(sum>0)//����:ʣ������>0
        {
            //����
            GameObject card = Instantiate(Resources.Load("Card")) as GameObject;//���ɲ��ظ������
            card.transform.SetParent(Putcard.transform);//����������
            card.transform.localScale = new Vector3(1, 1, 1);
            card.GetComponent<ThisCard>().thisId = H[--sum];
            card.name = "Card" + H[sum];

            //�ж�
            lastvalue = thisvalue;
            thisvalue = card.GetComponent<ThisCard>().thisId / 13;
            if (lastvalue == thisvalue) clear_put();//����ɫ��ͬ�����������������Ʒָ���ǰ��ң�����ջ�ɫ����

            //�غ��л�
            turn_change();
        }
    }

    public void clear()//�������Ŀ���
    {
        Transform c0 = GameObject.Find("0cards").transform;//���0
        foreach(Transform type in c0)
        {
            foreach(Transform card in type)
            {
                Destroy(card.gameObject);
            }
        }

        Transform c1 = GameObject.Find("1cards").transform;//���1
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

    public void Set_Card()//��ҳ��ƣ��������һ��ѡ�е����ƣ��ƶ���������
    {
        GameObject s = sc.GetComponent<Scriptscontrol>().scard;//sΪ����Ŀ���
        int p = 1;
        if (cou0.activeSelf) p = 0;
        if ((s) && (p == s.GetComponent<ThisCard>().place))//����:ѡ�����ƴ��� && ��ǰ���==�����������
        {
            //����
            s.transform.SetParent(Putcard.transform);//����������
            s.GetComponent<ThisCard>().place = 2;
            if (p == 0) a--;
            else b--;//����������


            //�ж�
            lastvalue = thisvalue;
            thisvalue = s.GetComponent<ThisCard>().thisId / 13;
            if (lastvalue == thisvalue) clear_put();//����ɫ��ͬ�����������������Ʒָ���ǰ��ң�����ջ�ɫ����

            //�غ��л�
            turn_change();
        }
    }

    public void clear_put()//����
    {
        List<Transform> children = new List<Transform>();//�洢����������
        int p = 1;//��ǰ���
        if (cou0.activeSelf) p = 0;
        foreach (Transform child in Putcard.transform) children.Add(child);
        foreach (Transform card in children)
        {
            card.gameObject.GetComponent<ThisCard>().place = p;//���ÿ����������
            card.SetParent(GameObject.Find(p + "type" + card.GetComponent<ThisCard>().thisId / 13).transform);
            if (p==0) a++;
            else b++;//����������
        }
        lastvalue = thisvalue = -1;
    }

    public void turn_change()//�غ��л�(����cou0�Ƿ���ʾ)
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


        if (sc.GetComponent<Scriptscontrol>().scard) sc.GetComponent<Scriptscontrol>().scard.transform.localScale = new Vector3(1, 1, 1);//֮ǰѡ�п�����С
        sc.GetComponent<Scriptscontrol>().scard = null;//���ѡ������
        GameObject.Find("0Text").GetComponent<Text>().text = "����: " + a;//�������0����
        GameObject.Find("1Text").GetComponent<Text>().text = "����: " + b;//�������1����
        getcard_num.text = "����:" + sum;//����ʣ������
        if (sum == 0) //�������
        {
            cou0.SetActive(false);
            cou1.SetActive(false);
            chu0.SetActive(false);
            chu1.SetActive(false);
            Getcard.SetActive(false);
            js.SetActive(true);
            js.transform.Find("Text3").GetComponent<Text>().text = "p1: " + a + "    " + "p2: " + b;
            string k;
            if (a == b) k = "ƽ�֣�";
            else if (a > b) k = "Player2 ��ʤ";
            else k = "Player1 ��ʤ";
            js.transform.Find("Text4").GetComponent<Text>().text = k;
        }
    }

    public void pc()//�˻�ģʽ
    {
        mode = 0;
        GameObject.Find("start").SetActive(false);
    }

    public void pp()//����ģʽ
    {
        mode = 1;
        GameObject.Find("start").SetActive(false);
    }

    public void ol()//����ģʽ(δ����)
    {
        mode = 2;
        texterror.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }
}