using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public Scriptscontrol sc;//ȫ�ֿ��ƽű�
    public Card thisCard = new Card();//����thisId��ȡ���ݿ��ж�Ӧ�Ŀ���
    public int thisId;

    public Image thatImage;
    public int id;//���0-89,���ݱ��ȷ�����Ƽ���̬����ͼƬ
    public int score;//����
    public int fcz;//������
    public int color;//1-5����Ȼ�����
    public int[] cost = { 0, 0, 0, 0, 0 };
    public int get7;//�õ����̱�ʯ
    public int rank;//�ȼ�

    public int place = 1;//������,������,����: 1,2,3

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
        if (sc.scard) sc.scard.transform.localScale = new Vector3(1, 1, 1);//֮ǰѡ�п�����С
        if (this.gameObject == sc.scard)
        {
            sc.scard = null;
            return;
        }
        transform.localScale = new Vector3(1.3f, 1.3f, 1.2f);//��ǰѡ�п��ƷŴ�
        sc.scard = transform.gameObject;//����ѡ�еĿ���
    }

    public void genxin()//���¿�(��̬)������UI
    {
        thisCard = CardDataBase.cardlist[thisId];//���ӿ������ݿ�
        
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
