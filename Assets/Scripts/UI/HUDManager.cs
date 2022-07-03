using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    [Header("Date Time")]
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI day;
    [SerializeField] private TextMeshProUGUI date;

    private void Start()
    {
        SetDateTime();
    }
    private void SetDateTime()
    {
        day.SetText(DateTime.Now.DayOfWeek.ToString());
        date.SetText(DateTime.Now.Date.Day.ToString());

        

        StartCoroutine(nameof(StartTime));
       
    }
    private IEnumerator StartTime()
    {
        while (true)
        {
            var hour = DateTime.Now.TimeOfDay.Hours;
            var mins = DateTime.Now.TimeOfDay.Minutes;

            var timeFormat = string.Format("{0:00}:{1:00}", hour, mins);
            time.SetText(timeFormat);

            yield return new WaitForSecondsRealtime(1f);
        }
    }

}
