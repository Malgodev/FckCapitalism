using Malgo.FckCapitalism.Card;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        [SerializeField] protected Dictionary<LandscapeStat, float> monthlyEffects = new Dictionary<LandscapeStat, float>();

        [SerializeField] private LandscapeData landscapeData;
        #endregion

        #region Private fields
        #endregion

        #region Public fields
        public float SpecialStat => specialStat;
        public LandscapeType LandscapeType => landscapeType;
        public List<LandscapeStatData> LandscapeStats => landscapeStats;


        public LandscapeStatData Profit => GetLandscapeStat(LandscapeStat.Profit);
        public LandscapeStatData Population => GetLandscapeStat(LandscapeStat.Population);
        public LandscapeStatData Stress => GetLandscapeStat(LandscapeStat.Stress);
        public LandscapeStatData Pollution => GetLandscapeStat(LandscapeStat.Pollution);
        public LandscapeStatData Technology => GetLandscapeStat(LandscapeStat.Technology);
        public LandscapeStatData Knowledge => GetLandscapeStat(LandscapeStat.Knowledge);
        public LandscapeStatData Jobless => GetLandscapeStat(LandscapeStat.Jobless);
        #endregion

        public static event Action<LandscapeType> OnSidePanelChanged;
        public static event Action OnSidePanelUpdated;

        protected virtual void Awake()
        {
            landscapeType = landscapeData.landscape;

            landscapeStats = new List<LandscapeStatData>();
            foreach (LandscapeStatData landscapeStat in landscapeData.landscapeStats)
            {
                landscapeStats.Add(new LandscapeStatData(landscapeStat));
            }

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


            foreach (LandscapeStatData landscapeStat in landscapeStats)
            {
                float value = monthlyEffects.GetValueOrDefault(landscapeStat.Stat, 0);

                landscapeStat.ChangeValue_Add(value);
            }

            GameData.Instance.IncreaseMoney(Profit.Value);
        }

        public LandscapeStatData GetLandscapeStat(LandscapeStat stat)
        {
            foreach (LandscapeStatData landscapeStat in landscapeStats)
            {
                if (landscapeStat.Stat == stat)
                {
                    return landscapeStat;
                }
            }

            return null;
        }

        public float GetLandscapeStatValue(LandscapeStat stat)
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

        protected virtual void OnMouseOver()
        {
            if (HandController.Instance.IsDraggingCard())
            {
                OnSidePanelChanged?.Invoke(landscapeType);
            }
        }

        public virtual void OnCardApply(CardData card)
        {
            foreach (LandscapeStatEffect effect in card.initialEffects)
            {
                UpdateValue(effect.Stat, effect.value);
            }

            foreach (LandscapeStatEffect effect in card.monthlyEffects)
            {
                if (!monthlyEffects.ContainsKey(effect.Stat))
                {
                    monthlyEffects[effect.Stat] = 0;
                }

                monthlyEffects[effect.Stat] += effect.value;
            }

            OnSidePanelUpdated?.Invoke();
        }

        private void UpdateValue(LandscapeStat statType, float value)
        {
            switch (statType)
            {
                case LandscapeStat.Profit:
                    Profit.ChangeValue_Mul(value);
                    break;

                case LandscapeStat.Population:
                    Population.ChangeValue_Add(value);
                    break;

                case LandscapeStat.Stress:
                    Stress.ChangeValue_Add(value);
                    break;

                case LandscapeStat.Pollution:
                    Pollution.ChangeValue_Add(value);
                    break;

                case LandscapeStat.Technology:
                    Technology.ChangeValue_Add(value);
                    break;

                case LandscapeStat.Knowledge:
                    Knowledge.ChangeValue_Add(value);
                    break;

                case LandscapeStat.Jobless:
                    Jobless.ChangeValue_Add(value);
                    break;
            }
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