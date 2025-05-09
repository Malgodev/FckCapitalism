using Malgo.FckCapitalism;
using Malgo.Utilities;
using System;
using TMPro;
using UnityEngine;

namespace Malgo.FckCapitalism.UI
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private void OnEnable()
        {
            GameData.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnMoneyChanged(float currentMoeny, float delta)
        {
            moneyText.text = NumberUtility.NumberNormalize(currentMoeny) + " $";
        }

        private void OnDisable()
        {
            GameData.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}