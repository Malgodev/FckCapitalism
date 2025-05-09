using Malgo.Singleton;
using System;
using UnityEngine;

namespace Malgo.FckCapitalism
{
    public class GameData : Singleton<GameData>
    {
        [SerializeField] private Clock currentTime;
        public Clock CurrentTime => currentTime;

        [SerializeField] private float currentMoney = 0f;
        public float CurrentMoney => currentMoney;

        public static event Action<float, float> OnMoneyChanged;

        public override void Init()
        {

        }

        private void Update()
        {
            currentTime.AddTime(Time.deltaTime);
        }

        private void IncreaseMoney(float value)
        {
            currentMoney += value;
            OnMoneyChanged?.Invoke(currentMoney, value);
        }

        private void SetMoney(float value)
        {
            currentMoney = value;
            OnMoneyChanged?.Invoke(currentMoney, currentMoney - value);
        }

        private void DecreaseMoney(float value)
        {
            currentMoney -= value;
            OnMoneyChanged?.Invoke(currentMoney, -value);
        }
    }

    [Serializable]
    public struct Clock
    {
        public float CurrentTime;
        public float TimeScale; // 3 seconds = 1 month

        public void AddTime(float deltaTime)
        {
            CurrentTime += deltaTime;
        }

        public string GetData()
        {
            int currentMonth = (int)(CurrentTime / TimeScale);
            int year = (int)(currentMonth / 12) + 2025;
            int month = currentMonth % 12 + 1;

            return $"{year}/{month.ToString("D2")}";
        }
    }
}