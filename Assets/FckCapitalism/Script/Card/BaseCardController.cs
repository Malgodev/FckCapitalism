using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class BaseCardController : MonoBehaviour
    {
        BoxCollider2D cardCollider;

        public static event Action<BaseCardController> OnCardStartHover;
        public static event Action<BaseCardController> OnCardEndHover;

        private void Awake()
        {
            cardCollider = GetComponent<BoxCollider2D>();
        }

        private void OnMouseEnter()
        {
            OnCardStartHover?.Invoke(this);
        }

        private void OnMouseDrag()
        {
            
        }

        private void OnMouseUp()
        {
            
        }

        private void OnMouseExit()
        {
            OnCardEndHover?.Invoke(this);
        }
    }
}
