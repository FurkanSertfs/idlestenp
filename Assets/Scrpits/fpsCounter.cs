using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fpsCounter : MonoBehaviour
{
    public Text fpsText;
    float pollingTime = 1f;
    float time;
    int frameCount;
   
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = frameRate.ToString() + " Fps";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
