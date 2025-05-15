using DG.Tweening;
using Malgo.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    public class HandController : Singleton<HandController>
    {
        [Header("Card Information")]
        [SerializeField] private int numberOfCard;
        [SerializeField] private BaseCardController cardPrefab;

        [SerializeField] private float xPadding = 1f;
        [SerializeField] private float angleDifferent = 5f;
        [SerializeField] private float arcHeight = 30f;

        List<BaseCardController> cardsInHand = new List<BaseCardController>();

        public override void Init()
        {
        }

        void Start()
        {
            SpawnCard();
        }

        private void SpawnCard()
        {
            float startX = -(numberOfCard - 1f) * xPadding / 2f;
            float startAngle = (numberOfCard - 1f) * angleDifferent / 2f;

            List<CardData> cards = DeckController.Instance.GenerateHandCard(numberOfCard);

            for (int i = 0; i < numberOfCard; i++)
            {
                BaseCardController newCard = Instantiate(cardPrefab, transform);

                float xPos = startX + i * xPadding;

                float t = (float)i / (numberOfCard - 1f);
                float yOffset = -Mathf.Pow(t - 0.5f, 2) * 4f * arcHeight + arcHeight;

                float zRot = startAngle - i * angleDifferent;

                newCard.transform.localPosition = new Vector3(xPos, yOffset, -i);
                newCard.transform.localRotation = Quaternion.Euler(0, 0, zRot);

                newCard.Initialize(i, cards[i]);

                cardsInHand.Add(newCard);
            }
        }

        public void RemoveCard(BaseCardController cardController)
        {
            cardsInHand.Remove(cardController);
            Destroy(cardController.gameObject);
            UpdateCardPosition();
        }
        private void UpdateCardPosition()
        {
            float startX = -(cardsInHand.Count - 1f) * xPadding / 2f;
            float startAngle = (cardsInHand.Count - 1f) * angleDifferent / 2f;

            for (int i = 0; i < cardsInHand.Count; i++)
            {
                float xPos = startX + i * xPadding;

                float t = (cardsInHand.Count == 1) ? 0.5f : (float)i / (cardsInHand.Count - 1f);
                float yOffset = -Mathf.Pow(t - 0.5f, 2) * 4f * arcHeight + arcHeight;

                float zRot = startAngle - i * angleDifferent;

                cardsInHand[i].transform.localPosition = new Vector3(xPos, yOffset, -i);
                cardsInHand[i].transform.localRotation = Quaternion.Euler(0, 0, zRot);

                cardsInHand[i].UpdateTransform();
            }
        }

        public bool IsDraggingCard()
        {
            foreach (BaseCardController card in cardsInHand)
            {
                if (card.IsDragging)
                {
                    return true;
                }
            }

            return false;
        }
    }
}