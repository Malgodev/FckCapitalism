using Malgo.FckCapitalism;
using Malgo.Utilities;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private void Update()
        {
            moneyText.text = NumberUtility.NumberNormalize(GameData.Instance.CurrentMoney) + " $";
        }
    }
}