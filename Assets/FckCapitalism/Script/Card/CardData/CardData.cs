using Malgo.FckCapitalism.Landscape;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public Sprite cardSprite;
        public List<LandscapeType> applicableLandscapes;
        public List<LandscapeStatData> initialEffects;
        public List<LandscapeStatData> monthlyEffects;
    }

    [Serializable]
    public struct LandscapeStatData
    {
        public LandscapeStat Stat;
        public float value;
    }
}