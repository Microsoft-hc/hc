using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_effect : MonoBehaviour
{

    public Transform Effect_object;
    public Transform Invalid_object;
    public Canvas Start_Canvas;
    public Canvas Setting_Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Control_change(){
        Effect_object.gameObject.SetActive(true);
        Invalid_object.gameObject.SetActive(false);
    }
    
    public void T_Click_Canvas(){
        Start_Canvas.enabled = false;
        Setting_Canvas.enabled = true;
    }
}
