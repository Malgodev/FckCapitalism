using Malgo.FckCapitalism.Landscape;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Malgo.FckCapitalism.UI.SidePanel
{
    public class LandscapeUIController : MonoBehaviour
    {
        [Header("UI Component")]
        [SerializeField] private TMP_Text landscapeNameText;

        [SerializeField] private StatUIController specialStat;

        [SerializeField] private RectTransform landscapeStatParent;

        [Header("Misc")]
        [SerializeField] private StatUIController statUIPrefab;
        [SerializeField] private SideUIData sideUIData;

        BaseLandscapeController landscapeController;
        Dictionary<LandscapeStat, StatUIController> statUIControllers = new Dictionary<LandscapeStat, StatUIController>();

        public void Initialize(BaseLandscapeController landscapeController)
        {
            landscapeNameText.text = landscapeController.LandscapeType.ToString();

            specialStat.Initialize(sideUIData.GetSpecialStat(landscapeController.LandscapeType));

            foreach (LandscapeStatData landscapeStat in landscapeController.LandscapeStats)
            {
                StatUIController statUIController = Instantiate(statUIPrefab, landscapeStatParent);

                SideUIDataStruct displayType = sideUIData.GetSideUIData(landscapeStat.Stat);

                statUIController.Initialize(displayType);

                statUIControllers.Add(landscapeStat.Stat, statUIController);
            }

            this.landscapeController = landscapeController;
        }

        private void OnEnable()
        {
            BaseLandscapeController.OnSidePanelUpdated += BaseLandscapeController_OnSidePanelUpdated;
            GameData.OnSecondPassed += GameData_OnSecondPassed; ;

            BaseLandscapeController_OnSidePanelUpdated();
        }

        private void GameData_OnSecondPassed(float obj)
        {
            BaseLandscapeController_OnSidePanelUpdated();
        }

        private void BaseLandscapeController_OnSidePanelUpdated()
        {
            specialStat.UpdateValue(landscapeController == null ? 0 : landscapeController.SpecialStat);

            foreach (KeyValuePair<LandscapeStat, StatUIController> statUIController in statUIControllers)
            {
                float value = landscapeController.GetLandscapeStatValue(statUIController.Key);
                statUIController.Value.UpdateValue(value);
            }
        }

        private void OnDisable()
        {
            BaseLandscapeController.OnSidePanelUpdated -= BaseLandscapeController_OnSidePanelUpdated;
            GameData.OnSecondPassed -= GameData_OnSecondPassed;
        }
    }
}