using Malgo.FckCapitalism;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Malgo.FckCapitalism.UI
{
    public class CalendarUIController : MonoBehaviour
    {
        [SerializeField] private float timeScale;

        [SerializeField] private TMP_Text calendarText;

        private void Awake()
        {
        }

        private void OnEnable()
        {
            GameData.OnSecondPassed += UpdateTime;
        }

        private void UpdateTime(float currentTime)
        {
            UpdateCalendar(GetData(currentTime));
        }

        private void OnDisable()
        {
            GameData.OnSecondPassed -= UpdateTime;
        }

        private void UpdateCalendar(string calendar)
        {
            calendarText.text = calendar;
        }

        public string GetData(float time)
        {
            int currentMonth = (int)(time / timeScale);
            int year = (int)(currentMonth / 12) + 2025;
            int month = currentMonth % 12 + 1;

            return $"{year}/{month.ToString("D2")}";
        }
    }
}