using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card : MonoBehaviour
{
    //��Ҫ��ʯ������ø�������������̱�ʯ����id>=70������̱�ʯ���������ɫ��1-5��
    //�Ƿ��ѡ�񣨹���
    public int id;//���0-89,���ݱ��ȷ�����Ƽ���̬����ͼƬ
    public int score;//����
    public int fcz;//������
    public int color;//1-5����Ȼ�����
    public Sprite image;//ͼƬ
    //���ѱ�ʯ����
    public int[] cost = { 0, 0, 0, 0, 0 };
    public int get7 = 0;//�õ����̱�ʯ
    public int rank = 1;//�ȼ�

    public Card()
    {

    }

    public Card(int i,int c,int s,int f,int c1,int c2, int c3, int c4, int c5)//��ţ���ɫ�������������ߣ�����
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
        if (rank==3) get7 = 1;//�̱�ʯ
        i++;
        image = Resources.Load<Sprite>("Cards/M" + i);//ͼƬ
    }

}
