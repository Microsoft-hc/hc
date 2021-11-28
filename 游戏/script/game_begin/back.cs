using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Button>().onClick.AddListener(ButtonClick);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting_button(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void back_before(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Back_ButtonClick()
    {
        Debug.Log("返回上一级");
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
