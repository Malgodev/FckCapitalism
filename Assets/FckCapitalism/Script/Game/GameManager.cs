using Malgo.Singleton;
using UnityEngine;

namespace Malgo.FckCapitalism
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameState gameState = GameState.MainMenu;
        public GameState GameState => gameState'

        public override void Init()
        {
            DontDestroyOnLoad(this.gameObject);
            Application.targetFrameRate = 60;
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