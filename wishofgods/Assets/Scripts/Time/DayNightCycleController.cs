using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface DayNightInterface 
{
    void GetComponent();
    void SetParameter(float time);

}

[ExecuteInEditMode]
public class DayNightCycleController : MonoBehaviour
{
    // 0 day 1 night
    [Range(0, 1)]
    public float time;
    public DayNightInterface[] setters;
    public bool day;

    //actions so specific events can happen an specific times
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float minToRealTime = 0.5f;
    private float timer;

    private void Start()
    {
        //start of day
        Minute = 0;
        Hour = 10;
        timer = minToRealTime;
    }
    private void OnEnable()
    {
        time = 0;
        day = true;
        GetSetters();
    }

    //try to get colors to change with color
    private void GetSetters()
    {
        setters = GetComponentsInChildren<DayNightInterface>();
        foreach (var setter in setters)
        {
            setter.GetComponent();
        }
    }

    void Update()
    {
        if(setters.Length > 0) 
        {
            foreach (var setter in setters)
            {
                setter.SetParameter(time);
            }
        }

        timer -= Time.deltaTime;

        //change time on clock
        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if(Minute >= 60)
            {
                Hour++;
                if(Hour >= 24)
                {
                    Hour = 0;
                }
                Minute = 0;
                OnHourChanged?.Invoke();
            }
            timer = minToRealTime;
        }
        if (time > 1f)
        {
            day = false;
        }
        if (time < 0f)
        {
            day = true;
        }

        // wie mappe ich den Lerp auf die Minutes and Hours??
        if (day)
        {
            time = Mathf.Lerp(time, 1f, Time.deltaTime * 0.05f);
        }
        else if (!day)
        {
            time = Mathf.Lerp(time, -0.1f, Time.deltaTime * 0.05f);
        }
    }
}
