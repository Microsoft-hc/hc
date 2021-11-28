using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_scaling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enter()//当鼠标在图标上时变大
    {
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }


    public void Exit()//恢复原始大小
    {
        transform.localScale = new Vector3(1.0f,1.0f,1.0f);
    }
    public void ApplicantionQuit()
    {
        Application.Quit();
    }
}
