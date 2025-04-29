using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private int numberOfCard;

        [SerializeField] private BaseCardController cardPrefab;

        [SerializeField] private float maximumAngle = 120f;
        [SerializeField] private float normalAngle = 45f;
        void Start()
        {
            SpawnCard();
        }

        private void SpawnCard()
        {
            for (int i = 0; i < numberOfCard; i++)
            {

            }
        }
    }

}