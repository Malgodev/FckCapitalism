using Malgo.FckCapitalism.Card;
using Malgo.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    public class DeckController : Singleton<DeckController>
    {
        [SerializeField] private List<CardData> cardList;
        public override void Init()
        {

        }

        public List<CardData> GetHandCard(int numberOfCard)
        {
            List<CardData> handCards = new List<CardData>();    
            for (int i = 0; i < numberOfCard; i++)
            {
                int randomIndex = Random.Range(0, cardList.Count);
                handCards.Add(cardList[randomIndex]);
            }

            return handCards;
        }
    }
}