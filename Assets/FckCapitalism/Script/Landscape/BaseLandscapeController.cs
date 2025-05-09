using Malgo.FckCapitalism.Card;
using System;
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
        Jungle,
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
        protected float baseProfit;
        protected float profitMultiplier;
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

        private void HandleUpdate()
        {
            
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