using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardlist = new List<Card>();//一级卡，40张
    //public static List<Card> cardlist2 = new List<Card>();//二级卡，30张
    //public static List<Card> cardlist3 = new List<Card>();//三级卡，20张

    public void Awake()
    {
        int i = 0;
        //编号，颜色，分数，复仇者，花费
        cardlist.Add(new Card(i++, 1, 1, 0, 0, 4, 0, 0, 0));
        cardlist.Add(new Card(i++, 1, 0, 0, 1, 1, 1, 1, 0));
        cardlist.Add(new Card(i++, 1, 0, 0, 0, 3, 0, 0, 0));
        cardlist.Add(new Card(i++, 1, 0, 0, 1, 2, 0, 0, 0));
        cardlist.Add(new Card(i++, 1, 0, 0, 0, 2, 0, 0, 2));
        cardlist.Add(new Card(i++, 1, 0, 0, 1, 2, 1, 1, 0));
        cardlist.Add(new Card(i++, 1, 0, 1, 0, 3, 0, 1, 1));
        cardlist.Add(new Card(i++, 1, 0, 1, 1, 2, 2, 0, 0));

        cardlist.Add(new Card(i++, 2, 1, 0, 0, 0, 0, 0, 4));
        cardlist.Add(new Card(i++, 2, 0, 0, 0, 0, 0, 0, 3));
        cardlist.Add(new Card(i++, 2, 0, 0, 1, 1, 0, 1, 2));
        cardlist.Add(new Card(i++, 2, 0, 0, 0, 1, 1, 1, 1));
        cardlist.Add(new Card(i++, 2, 0, 0, 0, 0, 1, 0, 2));
        cardlist.Add(new Card(i++, 2, 0, 0, 0, 0, 1, 0, 2));
        cardlist.Add(new Card(i++, 2, 0, 1, 0, 0, 1, 2, 2));
        cardlist.Add(new Card(i++, 2, 0, 1, 1, 0, 0, 1, 3));
        
        cardlist.Add(new Card(i++, 3, 0, 1, 3, 0, 1, 1, 0));
        cardlist.Add(new Card(i++, 3, 0, 0, 2, 1, 0, 1, 1));
        cardlist.Add(new Card(i++, 3, 0, 0, 2, 2, 0, 0, 0));
        cardlist.Add(new Card(i++, 3, 0, 1, 2, 1, 0, 0, 2));
        cardlist.Add(new Card(i++, 3, 1, 0, 4, 0, 0, 0, 0));
        cardlist.Add(new Card(i++, 3, 0, 0, 1, 0, 1, 1, 1));
        cardlist.Add(new Card(i++, 3, 0, 0, 3, 0, 0, 0, 0));
        cardlist.Add(new Card(i++, 3, 0, 0, 2, 0, 1, 0, 0));
        
        cardlist.Add(new Card(i++, 4, 0, 0, 0, 1, 1, 1, 1));
        cardlist.Add(new Card(i++, 4, 0, 0, 0, 0, 3, 0, 0));
        cardlist.Add(new Card(i++, 4, 1, 0, 0, 0, 4, 0, 0));
        cardlist.Add(new Card(i++, 4, 0, 0, 1, 0, 2, 0, 0));
        cardlist.Add(new Card(i++, 4, 0, 0, 0, 0, 2, 0, 2));
        cardlist.Add(new Card(i++, 4, 0, 0, 2, 1, 0, 1, 1));
        cardlist.Add(new Card(i++, 4, 0, 1, 0, 1, 3, 0, 1));
        cardlist.Add(new Card(i++, 4, 0, 1, 0, 2, 2, 1, 0));

        cardlist.Add(new Card(i++, 5, 1, 0, 0, 0, 0, 4, 0));
        cardlist.Add(new Card(i++, 5, 0, 0, 0, 1, 1, 1, 1));
        cardlist.Add(new Card(i++, 5, 0, 0, 0, 0, 0, 3, 0));
        cardlist.Add(new Card(i++, 5, 0, 0, 0, 0, 0, 2, 1));
        cardlist.Add(new Card(i++, 5, 0, 0, 0, 0, 2, 2, 0));
        cardlist.Add(new Card(i++, 5, 0, 0, 1, 1, 0, 2, 1));
        cardlist.Add(new Card(i++, 5, 0, 1, 1, 0, 1, 3, 0));
        cardlist.Add(new Card(i++, 5, 0, 1, 2, 1, 0, 2, 0));


        //编号，颜色，分数，复仇者，花费
        cardlist.Add(new Card(i++, 1, 1, 1, 3, 2, 0, 3, 0));
        cardlist.Add(new Card(i++, 1, 1, 1, 2, 0, 2, 3, 0));
        cardlist.Add(new Card(i++, 1, 2, 0, 0, 3, 0, 5, 0));
        cardlist.Add(new Card(i++, 1, 2, 0, 0, 0, 2, 4, 1));
        cardlist.Add(new Card(i++, 1, 3, 0, 0, 0, 0, 6, 0));
        cardlist.Add(new Card(i++, 1, 2, 0, 0, 0, 0, 5, 0));

        cardlist.Add(new Card(i++, 2, 3, 0, 6, 0, 0, 0, 0));
        cardlist.Add(new Card(i++, 2, 2, 0, 5, 0, 0, 0, 3));
        cardlist.Add(new Card(i++, 2, 2, 0, 5, 0, 0, 0, 0));
        cardlist.Add(new Card(i++, 2, 2, 0, 4, 2, 0, 1, 0));
        cardlist.Add(new Card(i++, 2, 1, 1, 3, 0, 3, 0, 2));
        cardlist.Add(new Card(i++, 2, 1, 1, 3, 2, 0, 0, 2));

        cardlist.Add(new Card(i++, 3, 1, 1, 0, 3, 0, 2, 2));
        cardlist.Add(new Card(i++, 3, 2, 0, 0, 5, 3, 0, 0));
        cardlist.Add(new Card(i++, 3, 2, 0, 0, 5, 0, 0, 0));
        cardlist.Add(new Card(i++, 3, 2, 0, 1, 4, 0, 2, 0));
        cardlist.Add(new Card(i++, 3, 1, 1, 0, 3, 3, 2, 0));
        cardlist.Add(new Card(i++, 3, 3, 0, 0, 6, 0, 0, 0));

        cardlist.Add(new Card(i++, 4, 3, 0, 0, 0, 0, 0, 6));
        cardlist.Add(new Card(i++, 4, 2, 0, 3, 0, 0, 0, 5));
        cardlist.Add(new Card(i++, 4, 2, 0, 0, 0, 0, 0, 5));
        cardlist.Add(new Card(i++, 4, 2, 0, 0, 1, 0, 2, 4));
        cardlist.Add(new Card(i++, 4, 1, 1, 3, 0, 2, 0, 3));
        cardlist.Add(new Card(i++, 4, 1, 1, 0, 2, 0, 2, 3));

        cardlist.Add(new Card(i++, 5, 3, 0, 0, 0, 6, 0, 0));
        cardlist.Add(new Card(i++, 5, 2, 0, 3, 0, 5, 0, 0));
        cardlist.Add(new Card(i++, 5, 2, 0, 0, 0, 5, 0, 0));
        cardlist.Add(new Card(i++, 5, 2, 0, 0, 1, 4, 2, 0));
        cardlist.Add(new Card(i++, 5, 1, 1, 0, 0, 3, 2, 3));
        cardlist.Add(new Card(i++, 5, 1, 1, 0, 2, 3, 0, 2));


        //编号，颜色，分数，复仇者，花费
        cardlist.Add(new Card(i++, 1, 5, 0, 0, 0, 0, 3, 7));
        cardlist.Add(new Card(i++, 1, 4, 1, 0, 0, 0, 0, 7));
        cardlist.Add(new Card(i++, 1, 4, 0, 3, 3, 0, 0, 6));
        cardlist.Add(new Card(i++, 1, 3, 2, 3, 0, 3, 3, 5));

        cardlist.Add(new Card(i++, 2, 3, 2, 0, 3, 5, 3, 3));
        cardlist.Add(new Card(i++, 2, 4, 1, 0, 3, 6, 0, 3));
        cardlist.Add(new Card(i++, 2, 5, 0, 3, 0, 7, 0, 0));
        cardlist.Add(new Card(i++, 2, 4, 0, 0, 0, 7, 0, 0));

        cardlist.Add(new Card(i++, 3, 5, 0, 0, 0, 0, 7, 3));
        cardlist.Add(new Card(i++, 3, 4, 0, 0, 0, 0, 7, 0));
        cardlist.Add(new Card(i++, 3, 4, 1, 3, 0, 3, 6, 0));
        cardlist.Add(new Card(i++, 3, 3, 2, 3, 3, 3, 5, 0));

        cardlist.Add(new Card(i++, 4, 5, 0, 7, 3, 0, 0, 0));
        cardlist.Add(new Card(i++, 4, 4, 0, 7, 0, 0, 0, 0));
        cardlist.Add(new Card(i++, 4, 4, 1, 6, 3, 3, 0, 0));
        cardlist.Add(new Card(i++, 4, 3, 2, 5, 0, 3, 3, 3));

        cardlist.Add(new Card(i++, 5, 5, 0, 0, 7, 3, 0, 0));
        cardlist.Add(new Card(i++, 5, 4, 0, 0, 7, 0, 0, 0));
        cardlist.Add(new Card(i++, 5, 4, 1, 0, 6, 0, 3, 3));
        cardlist.Add(new Card(i++, 5, 3, 2, 3, 5, 0, 3, 3));
    }
}
