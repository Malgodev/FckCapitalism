using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    public class HandController : MonoBehaviour
    {
        [Header("Card Information")]
        [SerializeField] private int numberOfCard;
        [SerializeField] private BaseCardController cardPrefab;

        [SerializeField] private float xPadding = 1f;
        [SerializeField] private float angleDifferent = 5f;
        [SerializeField] private float arcHeight = 30f;

        List<BaseCardController> cardsInHand = new List<BaseCardController>();

        void Start()
        {
            SpawnCard();
        }

        private void SpawnCard()
        {
            float startX = -(numberOfCard - 1f) * xPadding / 2f;
            float startAngle = (numberOfCard - 1f) * angleDifferent / 2f;

            for (int i = 0; i < numberOfCard; i++)
            {
                BaseCardController newCard = Instantiate(cardPrefab, transform);

                float xPos = startX + i * xPadding;

                float t = (float)i / (numberOfCard - 1f);
                float yOffset = -Mathf.Pow(t - 0.5f, 2) * 4f * arcHeight + arcHeight;

                float zRot = startAngle - i * angleDifferent;

                newCard.transform.localPosition = new Vector3(xPos, yOffset, -i);
                newCard.transform.localRotation = Quaternion.Euler(0, 0, zRot);

                newCard.Initialize(i);
            }
        }

        private void UpdateCardPosition()
        {
            foreach (BaseCardController card in cardsInHand)
            {
                float t = (float)cardsInHand.IndexOf(card) / (numberOfCard - 1f);
                float yOffset = -Mathf.Pow(t - 0.5f, 2) * 4f * arcHeight + arcHeight;
                card.transform.DOLocalMoveY(yOffset, 0.5f);
            }
        }
    }
}