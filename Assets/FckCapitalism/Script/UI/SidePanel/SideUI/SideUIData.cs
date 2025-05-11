using Malgo.FckCapitalism.Landscape;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.UI.SidePanel
{
    [CreateAssetMenu(fileName = "SideUIData", menuName = "ScriptableObjects/SideUIData", order = 2)]
    public class SideUIData : ScriptableObject
    {
        public List<LandscapeSpecialStat> specialStats;
        public List<SideUIDataStruct> sideUIDataStructs;

        public SideUIDataStruct GetSideUIData(LandscapeStat statType)
        {
            foreach (SideUIDataStruct sideUIDataStruct in sideUIDataStructs)
            {
                if (sideUIDataStruct.statType == statType)
                {
                    return sideUIDataStruct;
                }
            }
            Debug.LogError($"No data found for {statType}");
            return default;
        }

        public LandscapeSpecialStat GetSpecialStat(LandscapeType landscapeType)
        {
            foreach (LandscapeSpecialStat specialStat in specialStats)
            {
                if (specialStat.landscapeType == landscapeType)
                {
                    return specialStat;
                }
            }
            Debug.LogError($"No data found for {landscapeType}");
            return default;
        }
    }

    [Serializable]
    public struct LandscapeSpecialStat
    {
        public LandscapeType landscapeType;
        public string name;
        public Sprite icon;
    }


    [Serializable]
    public struct SideUIDataStruct
    {
        public LandscapeStat statType;
        public Sprite icon;
        public StatDisplayType statDisplayType;
    }

    public enum StatDisplayType
    {
        Number,
        Percentage,
    }
}

