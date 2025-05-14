using Malgo.FckCapitalism.Landscape;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public LandscapeType applicableLandscape;
    }
}