using System;
using System.Collections;
using Scriptable_Objects;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] private PersistantData data;


        [Header("Date Time")] [SerializeField] private TextMeshProUGUI time;
        [SerializeField] private TextMeshProUGUI day;
        [SerializeField] private TextMeshProUGUI date;
        [Header("Cash")] [SerializeField] private TextMeshProUGUI cashText;

        private void Awake()
        {
            data.cash = PlayerPrefs.GetInt("Cash", 10000);
        }

        private void Start()
        {
            SetDateTime();
            SetCash();
        }

        public void SetCash()
        {
            cashText.SetText(data.cash.ToString() + " $");
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
}