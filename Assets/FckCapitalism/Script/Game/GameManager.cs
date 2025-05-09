using Malgo.Singleton;
using System;
using UnityEngine;

namespace Malgo.FckCapitalism
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameState gameState = GameState.MainMenu;
        public GameState GameState => gameState;

        public static event Action<GameState> OnGameStateChanged;

        public override void Init()
        {
            DontDestroyOnLoad(this.gameObject);
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            UpdateGameState(gameState);
        }

        public void UpdateGameState(GameState targetGameState)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    // Handle main menu state
                    break;
                case GameState.Playing:
                    // Handle playing state
                    break;
                case GameState.Pause:
                    // Handle pause state
                    break;
                case GameState.End:
                    // Handle end state
                    break;
            }

            gameState = targetGameState;
            OnGameStateChanged?.Invoke(gameState);
        }
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        End,
    }
}