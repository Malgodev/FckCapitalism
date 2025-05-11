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
        [SerializeField] private Transform landscapeParent;
        //private Dictionary<LandscapeType, BaseLandscapeController> landscapes = new Dictionary<LandscapeType, BaseLandscapeController>();

        [Header("Landscape stat")]
        [SerializeField] private LandscapeUIController landscapeUIControllerPrefab;
        [SerializeField] private Dictionary<LandscapeType, LandscapeUIController> landscapeUIControllers 
            = new Dictionary<LandscapeType, LandscapeUIController>();

        private LandscapeUIController currentLandscapeUI;

        // TODO A really bad code, but it works for now
        private void Start()
        {
            foreach (Transform child in landscapeParent)
            {
                BaseLandscapeController landscape = child.GetComponent<BaseLandscapeController>();
                if (landscape != null)
                {
                    LandscapeUIController landscapeUIController = Instantiate(landscapeUIControllerPrefab, this.transform);

                    landscapeUIController.Initialize(landscape);

                    landscapeUIControllers.Add(landscape.LandscapeType, landscapeUIController);

                    landscapeUIController.gameObject.SetActive(false);
                }
            }

            HandleSidePanelChanged(LandscapeType.Electroscape);
        }

        private void OnEnable()
        {
                BaseLandscapeController.OnSidePanelChanged += HandleSidePanelChanged;
        }

        private void HandleSidePanelChanged(LandscapeType landscape)
        {
            currentLandscapeUI?.gameObject.SetActive(false);

            if (landscapeUIControllers.TryGetValue(landscape, out LandscapeUIController landscapeUIController))
            {
                currentLandscapeUI = landscapeUIController;
                currentLandscapeUI.gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
            BaseLandscapeController.OnSidePanelChanged -= HandleSidePanelChanged;
        }
    }
}