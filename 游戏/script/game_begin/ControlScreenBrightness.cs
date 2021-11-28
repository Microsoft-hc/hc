using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using UnityEngine.UI;
 
public class ControlScreenBrightness : MonoBehaviour
{
    /// <summary>slider：控制屏幕亮度</summary>
    public GameObject obj_slider;
 
    public GameObject obj_text;
 
    // Use this for initialization
    void Start()
    {
    #if UNITY_IOS
 
    #elif UNITY_EDITOR
        return;
    #elif UNITY_ANDROID
        SetApplicationBrightnessTo(1);
    #endif
        SetApplicationBrightnessTo(1);
    
    }
 
    // Update is called once per frame
    void Update()
    {
        float tmp = obj_slider.GetComponent<Slider>().value;
        obj_text.GetComponent<Text>().text = tmp.ToString();
 
    #if UNITY_IOS
 
    #elif UNITY_EDITOR
        return;
    #elif UNITY_ANDROID        
         SetApplicationBrightnessTo(tmp);        
    #endif       
    }
 
    public void SetApplicationBrightnessTo(float Brightness)//通过slider调节屏幕亮度
    {
        AndroidJavaObject Activity = null;

        Activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        
        Activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            AndroidJavaObject Window = null, Attributes = null;
            Window = Activity.Call<AndroidJavaObject>("getWindow");
            Attributes = Window.Call<AndroidJavaObject>("getAttributes");
            Attributes.Set("screenBrightness", Brightness);
            Window.Call("setAttributes", Attributes);
        }));
    }
 
 
}