using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private void Update()
        {
            moneyText.text = NumberNormalize(GameData.Instance.CurrentMoney) + " $";
        }

        private string NumberNormalize(float number)
        {
            if (number >= 1_000_000_000)
            {
                return (number / 1_000_000_000).ToString("F2") + "B";
            }
            else if (number >= 1_000_000)
            {
                return (number / 1_000_000).ToString("F2") + "M";
            }
            else if (number >= 1_000)
            {
                return (number / 1_000).ToString("F2") + "K";
            }
            else
            {
                return number.ToString("F2");
            }
        }
    }
}