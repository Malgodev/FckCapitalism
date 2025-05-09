using Malgo.Singleton;
using System;
using UnityEngine;

namespace Malgo.FckCapitalism
{
    public class GameData : Singleton<GameData>
    {
        #region Private fields
        [SerializeField] private float currentMoney = 0f;
        [SerializeField] private float currentTime = 0f;

        private float updateInterval = 1f;
        private float updateTimer = 0f;
        #endregion

        #region Public fields
        public float CurrentTime => currentTime;
        public float CurrentMoney => currentMoney;
        #endregion


        public static event Action<float, float> OnMoneyChanged;
        public static event Action<float> OnSecondPassed;

        public override void Init()
        {

        }

        private void Start()
        {
            SetMoney(0f);
            OnSecondPassed?.Invoke(currentTime);
        }

        private void Update()
        {
            updateTimer += Time.deltaTime;

            if (updateTimer >= updateInterval)
            {
                updateTimer = 0f;
                
                currentTime++;
                OnSecondPassed?.Invoke(currentTime);
            }
        }

        public void IncreaseMoney(float value)
        {
            currentMoney += value;
            OnMoneyChanged?.Invoke(currentMoney, value);
        }

        public void SetMoney(float value)
        {
            currentMoney = value;
            OnMoneyChanged?.Invoke(currentMoney, currentMoney - value);
        }

        public void DecreaseMoney(float value)
        {
            currentMoney -= value;
            OnMoneyChanged?.Invoke(currentMoney, -value);
        }
    }
}