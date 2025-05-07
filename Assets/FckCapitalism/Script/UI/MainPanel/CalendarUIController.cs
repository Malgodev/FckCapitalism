using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CalendarUIController : MonoBehaviour
    {
        float updateInterval;
        float lastUpdateTime = 0f;

        [SerializeField] private TMP_Text calendarText;

        private void Awake()
        {
            updateInterval = GameData.Instance.CurrentTime.TimeScale;
            lastUpdateTime = updateInterval;
        }

        private void Update()
        {
            lastUpdateTime += Time.deltaTime;

            if (lastUpdateTime >= updateInterval)
            {
                lastUpdateTime = 0f;
                UpdateCalendar();
            }
        }

        private void UpdateCalendar()
        {
            calendarText.text = GameData.Instance.CurrentTime.GetData();
        }
    }

}