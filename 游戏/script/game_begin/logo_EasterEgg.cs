using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logo_EasterEgg : MonoBehaviour
{
    public static float Count = 0;//初始点击次数
    public GameObject ourimg;//声明物件
    // Start is called before the first frame update
    void Start()
    {
        ourimg = GameObject.Find("Our_Image");
        ourimg.SetActive(false);//让物体不生效
    }
    // Update is called once per frame
    void Awake(){
        
    }
    void Update()
    {
        logo_click();
    }
    //

    public void logo_click(){

            if (Input.GetMouseButtonUp(0))
            {
                Count += 1;
                //Count = Count ;
                Debug.Log(Count);
            
            }
            if((Count % 18==0 || Count % 18 ==1 )&& (Count != 0 &&Count != 1)){
                StartCoroutine(Disappear());//调用协程
            }
            else{
                ourimg.SetActive(false);//让物体不生效
            }
        }
    IEnumerator Disappear()//协程
    {   
        ourimg.SetActive(true);//让物体生效
        yield return new WaitForSeconds(2);//产生效果两秒

        
    }
   
        

}



//     //放到Text组件上

//     public void logo_click(){
//         int i=0;
//     }
// }
