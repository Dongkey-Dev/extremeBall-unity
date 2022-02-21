using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.1f;

    void Update(){
        if (Input.GetMouseButton(0)){
            DoSlowmotion();
        }
        else if (Input.GetMouseButtonUp(0)){
            GetBackTime();
        }
    }
    public void DoSlowmotion(){
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    public void GetBackTime(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
