using System;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] Detector _detector;
    [SerializeField] AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _detector.Detected += EnableAlarmSystem;
        _detector.UnDetected += DisableAlarmSystem;
    }

    private void OnDisable()
    {
        _detector.Detected -= EnableAlarmSystem;
        _detector.UnDetected -= DisableAlarmSystem;
    }

    private void EnableAlarmSystem()
    {
        _alarmSystem.TurnOn();
    }

    private void DisableAlarmSystem()
    {
        _alarmSystem.TurnOff();
    }

}
