using Malgo.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.UI
{
    public class CanvasManager : Singleton<CanvasManager>
    {
        [SerializeField] private GameObject gameCanvas;
        [SerializeField] private GameObject pauseCanvas;
        [SerializeField] private GameObject endCanvas;

        public override void Init()
        {
            
        }

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Playing:
                    EnablePanel(gameCanvas);
                    break;
                case GameState.Pause:
                    EnablePanel(pauseCanvas);
                    break;
                case GameState.End:
                    EnablePanel(endCanvas);
                    break;
            }
        }

        private void EnablePanel(GameObject panel)
        {
            gameCanvas.SetActive(false);
            pauseCanvas.SetActive(false);
            endCanvas.SetActive(false);

            panel.SetActive(true);
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= OnGameStateChanged;
        }
    }
}
