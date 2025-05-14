using UnityEngine;
using Utilities;

namespace Malgo.FckCapitalism.Card
{
    public class BaseCardController : MonoBehaviour
    {
        BoxCollider cardCollider;

        private int index;

        [SerializeField] private Transform cardSprite;
        [SerializeField] private LayerMask landscapeMask;

        // Caching
        Vector3 defaultPosition;
        Vector3 defaultRotation;

        Vector3 mousePosition;

        private bool isDragging = false;

        private void Awake()
        {
            cardCollider = GetComponent<BoxCollider>();
        }

        public void Initialize(int index)
        {
            this.index = index;
            //cardCollider.center = new Vector3(0, 0, -index / 100f);

            defaultPosition = cardSprite.localPosition;
            defaultRotation = this.transform.localRotation.eulerAngles;
        }

        private void OnMouseEnter()
        {
            cardSprite.localRotation = Quaternion.Euler(-defaultRotation);
            cardSprite.localPosition = new Vector3(defaultPosition.x, 1.2f, -11f);
            cardSprite.localScale = Vector3.one * 1.1f;
        }

        private void OnMouseDrag()
        {
            isDragging = true;

            mousePosition = MouseUtility.GetMouseWorldPosition();
            mousePosition.z = cardSprite.position.z;
            cardSprite.position = mousePosition;
        }

        private void OnMouseUp()
        {
            // TODO: Check if drag to valid landscape
            Collider2D targetLandscape = Physics2D.OverlapPoint(MouseUtility.GetMouseWorldPosition(), landscapeMask);


            SetDefaultTransform();

            isDragging = true;
        }

        private void OnMouseExit()
        {
            if (!isDragging)
            {
                SetDefaultTransform();
            }
        }

        private void SetDefaultTransform()
        {
            cardSprite.localScale = Vector3.one;
            cardSprite.localRotation = Quaternion.Euler(Vector3.zero);
            cardSprite.localPosition = defaultPosition;
        }

        private void OnDestroy()
        {

        }
    }
}
