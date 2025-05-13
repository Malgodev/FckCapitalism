using Malgo.FckCapitalism.Card;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public abstract class BaseLandscapeController : MonoBehaviour
    {
        #region Landscape stat
        [Header("Landscape stat")]
        protected LandscapeType landscapeType;

        [SerializeField] protected float specialStat;
        [SerializeField] protected List<LandscapeStatData> landscapeStats;

        [SerializeField] private LandscapeData landscapeData;
        #endregion

        #region Private fields
        #endregion

        #region Public fields
        public float SpecialStat => specialStat;
        public LandscapeType LandscapeType => landscapeType;
        public List<LandscapeStatData> LandscapeStats => landscapeStats;


        public float Profit => GetLandscapeStat(LandscapeStat.Profit);
        public float Population => GetLandscapeStat(LandscapeStat.Population);
        public float Stress => GetLandscapeStat(LandscapeStat.Stress);
        public float Pollution => GetLandscapeStat(LandscapeStat.Pollution);
        public float Technology => GetLandscapeStat(LandscapeStat.Technology);
        public float Knowledge => GetLandscapeStat(LandscapeStat.Knowledge);
        public float Jobless => GetLandscapeStat(LandscapeStat.Jobless);
        #endregion

        public static event Action<LandscapeType> OnSidePanelChanged;
        public static event Action OnSidePanelUpdated;

        protected virtual void Awake()
        {
            landscapeType = landscapeData.landscape;
            landscapeStats = new List<LandscapeStatData>(landscapeData.landscapeStats);

            specialStat = landscapeData.specialStatValue;
        }
        private void Start()
        {
            OnSidePanelUpdated?.Invoke();
        }

        private void OnEnable()
        {
            GameData.OnSecondPassed += HandleUpdate;
        }

        protected virtual void HandleUpdate(float currentTime)
        {
            if (GameManager.Instance.GameState != GameState.Playing)
            {
                return;
            }

            GameData.Instance.IncreaseMoney(Profit);
        }

        public float GetLandscapeStat(LandscapeStat stat)
        {
            foreach (LandscapeStatData landscapeStat in landscapeStats)
            {
                if (landscapeStat.Stat == stat)
                {
                    return landscapeStat.Value;
                }
            }

            return 0;
        }

        #region Card interaction
        protected virtual void OnMouseDown()
        {
            if (GameManager.Instance.GameState != GameState.Playing)
            {
                return;
            }

            OnSidePanelChanged?.Invoke(landscapeType);
        }

        protected virtual void OnCardStartHover()
        {

        }

        public virtual void OnCardApply(BaseCardController card)
        {
            Debug.Log(card.name + " applied to " + gameObject.name);
        }

        protected virtual void OnCardEndHover()
        {

        }
        #endregion

        private void OnDisable()
        {
            GameData.OnSecondPassed -= HandleUpdate;
        }
    }
}