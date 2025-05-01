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

        public static event Action<BaseCardController> OnCardStartHover;
        public static event Action<BaseCardController> OnCardEndHover;

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
            cardCollider.center = new Vector3(0, 0, -index);
        }

        private void OnMouseEnter()
        {
            OnCardStartHover?.Invoke(this);
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
            SetDefaultPosition();
        }

        private void OnMouseExit()
        {
            OnCardEndHover?.Invoke(this);
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
