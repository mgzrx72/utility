using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
public class ProfilerInformation : MonoBehaviour
{
    float Used ;
    
    int frameCount=0;
    float prevTime=0;
    int fps;
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Profiler");
        GUI.Label(new Rect(20, 35, 80, 20), Used.ToString("0.0") + " MB");
        GUI.Label(new Rect(20, 60, 80, 20), fps.ToString() + " FPS");
    }

    private void FixedUpdate()
    {
        Used = (Profiler.GetTotalAllocatedMemoryLong() >> 10) / 1024f;

       
    }

    private void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = Mathf.CeilToInt(frameCount / time);
            Debug.Log(fps);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }

}
