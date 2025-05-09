using Malgo.FckCapitalism.Card;
using System;
using System.Collections;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public enum LandscapeType
    {
        Electroscape,
        Seaport,
        Administrative,
        Factory,
        Mountain,
        City,
        Wasteland,
        Forest,
        Slum,
    }

    public enum LandscapeStat
    {
        Profit,
        Population,
        Stress,
        Pollution,
        Technology,
        Knowledge,
        Jobless
    }

    public abstract class BaseLandscapeController : MonoBehaviour
    {
        #region Landscape stat
        [SerializeField] protected LandscapeType landscapeType;

        protected float specialStat;
        public float SpecialStat => specialStat;
        #endregion

        #region Private fields
        private float updateInterval = 1f;
        private float updateTimer = 0f;


        [Header("Landscape stat")]
        protected float baseProfit = 10;
        protected float profitMultiplier = 1;
        #endregion

        #region Public fields
        public float Profit => (baseProfit * profitMultiplier);
        #endregion
        
        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            updateTimer += Time.deltaTime;

            if (updateTimer >= updateInterval)
            {
                updateTimer = 0f;
                HandleUpdate();
            }
        }

        protected virtual void HandleUpdate()
        {
            GameData.Instance.IncreaseMoney(Profit);
        }

        #region Card interaction
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
    }
}