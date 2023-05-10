using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void OnEnable()
    {
        DayNightCycleController.OnMinuteChanged += UpdateTime;
        DayNightCycleController.OnHourChanged += UpdateTime;
    }

    private void OnDisable()
    {
        DayNightCycleController.OnMinuteChanged -= UpdateTime;
        DayNightCycleController.OnHourChanged -= UpdateTime;
    }

    private void UpdateTime()
    {
        // time shown as 00:00
        timeText.text = $"{DayNightCycleController.Hour:00}:{DayNightCycleController.Minute:00}";
    }
}
