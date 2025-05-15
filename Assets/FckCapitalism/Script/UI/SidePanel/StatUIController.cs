using Malgo.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Malgo.FckCapitalism.UI.SidePanel
{
    public class StatUIController : MonoBehaviour
    {
        [SerializeField] private StatDisplayType statDisplayType;

        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text titleText;

        [SerializeField] private GameObject fill;
        [SerializeField] private SlicedFilledImage fillImage;
        [SerializeField] private TMP_Text fillText;

        [SerializeField] private TMP_Text text;

        public void Initialize(LandscapeSpecialStat specialStat)
        {
            statDisplayType = StatDisplayType.Percentage;
            this.icon.sprite = specialStat.icon;
            this.titleText.text = specialStat.name;

            fill.SetActive(true);
        }

        public void Initialize(SideUIDataStruct sideUIData)
        {
            this.titleText.text = sideUIData.statType.ToString();
            this.statDisplayType = sideUIData.statDisplayType;
            this.icon.sprite = sideUIData.icon;

            fill.SetActive(statDisplayType == StatDisplayType.Percentage);
            text.gameObject.SetActive(statDisplayType == StatDisplayType.Number);
        }

        public void UpdateValue(float value)
        {
            if (statDisplayType == StatDisplayType.Percentage)
            {
                UpdateFill(value);
            }
            else if (statDisplayType == StatDisplayType.Number)
            {
                UpdateText(value);
            }
        }

        public void UpdateText(float value)
        {
            text.text = NumberUtility.NumberNormalize(value);
        }

        public void UpdateFill(float value)
        {

            fillImage.fillAmount = value / 100f;
            fillText.text = value.ToString("F1") + "%";
        }
    }
}