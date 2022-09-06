using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    // Start is called before the first frame update

    private const float DegreesPerHour = -360f/12;
    private const float MinutesPerHour = -360f/60;
    private const float SecondsPerHour = -360f/60;
    
    void Start()
    {
    }
    void Awake()
    {
        var time = DateTime.Now;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, DegreesPerHour * time.Hour);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, MinutesPerHour * time.Minute);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, SecondsPerHour * time.Second);
    }

    // Update is called once per frame
    void Update()
    {
        var time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, DegreesPerHour * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, MinutesPerHour * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, SecondsPerHour * (float)time.TotalSeconds);
    }
}
