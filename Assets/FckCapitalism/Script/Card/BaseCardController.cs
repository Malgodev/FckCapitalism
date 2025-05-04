using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Card
{
    public class BaseCardController : MonoBehaviour
    {
        BoxCollider cardCollider;

        private int index;

        [SerializeField] private Transform cardSprite;
        [SerializeField] private LayerMask landscapeMask;

        // Caching
        Vector3 defaultPosition;
        Vector3 mousePosition;

        private void Awake()
        {
            cardCollider = GetComponent<BoxCollider>();
            defaultPosition = cardSprite.localPosition;
        }

        public void Initialize(int index)
        {
            this.index = index;
            cardCollider.center = new Vector3(0, 0, -index / 100f);
        }

        private void OnMouseDrag()
        {
            mousePosition = MouseUtility.GetMouseWorldPosition();
            mousePosition.z = cardSprite.position.z;
            cardSprite.position = mousePosition;
        }

        private void OnMouseUp()
        {
            // TODO: Check if drag to valid landscape
            Collider2D targetLandscape = Physics2D.OverlapPoint(MouseUtility.GetMouseWorldPosition(), landscapeMask);
            Debug.Log(targetLandscape.name);

            SetDefaultPosition();
        }

        private void SetDefaultPosition()
        {
            cardSprite.localPosition = defaultPosition;
        }

        private void OnDestroy()
        {

        }
    }
}
