using System;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    [CreateAssetMenu(fileName = "LandscapeData", menuName = "ScriptableObjects/LandscapeData", order = 1)]
    public class LandscapeData : ScriptableObject
    {
        public LandscapeType landscape;

        [Header("Special stat")]
        public string specialStatName;
        public Sprite specialStatIcon;
        public float specialStatValue;

        public List<LandscapeStatData> landscapeStats;

    }

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

    [Serializable]
    public struct LandscapeStatData
    {
        public LandscapeStat Stat;
        public float Value;
        public float Percentage => Value / MaxValue * 100f;
        public float MaxValue;


        public LandscapeStatData(LandscapeStat stat, float value, float maxValue)
        {
            Stat = stat;
            Value = value;
            MaxValue = maxValue;
        }

        public void SetValue(float value)
        {
            Value = value;
        }

        public void IncreaseValue(float value)
        {
            Value += value;
            if (MaxValue != 0 && Value > MaxValue)
            {
                Value = MaxValue;
            }
        }

        public void DecreaseValue(float value)
        {
            Value -= value;
            if (Value < 0)
            {
                Value = 0;
            }
        }
    }
}
