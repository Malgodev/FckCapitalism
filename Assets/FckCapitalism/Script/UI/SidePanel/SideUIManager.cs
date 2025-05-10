using Malgo.FckCapitalism.Landscape;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Malgo.FckCapitalism.UI.SidePanel
{
    public class SideUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text landscapeName;

        private void OnEnable()
        {
                BaseLandscapeController.OnSidePanelChanged += HandleSidePanelChanged;
        }

        private void HandleSidePanelChanged(LandscapeType landscape)
        {
            landscapeName.text = landscape.ToString();
        }
    }
}