using Malgo.FckCapitalism.Landscape;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Utilities;

namespace Malgo.FckCapitalism.Card
{
    public class BaseCardController : MonoBehaviour
    {
        BoxCollider cardCollider;

        private int index;

        CardData cardData;

        [Header("Components")]
        [SerializeField] private Transform mainCard;
        [SerializeField] private SpriteRenderer cardSprite;
        [SerializeField] private LayerMask landscapeMask;

        [Header("Text")]
        [SerializeField] private TMP_Text cardName;
        [SerializeField] private TMP_Text initialEffect;
        [SerializeField] private TMP_Text monthlyEffect;

        // Caching
        Vector3 defaultPosition;
        Vector3 defaultRotation;

        Vector3 mousePosition;

        private bool isDragging = false;
        public bool IsDragging => isDragging;
        private void Awake()
        {
            cardCollider = GetComponent<BoxCollider>();
        }

        public void Initialize(int index, CardData cardData)
        {
            this.index = index;
            cardName.text = cardData.cardName;
            cardSprite.sprite = cardData.cardSprite;

            this.cardData = cardData;

            defaultPosition = mainCard.localPosition;
            defaultRotation = this.transform.localRotation.eulerAngles;
        }

        public void UpdateTransform()
        {
            defaultPosition = mainCard.localPosition;
            defaultRotation = this.transform.localRotation.eulerAngles;
        }

        private void OnMouseEnter()
        {
            mainCard.localRotation = Quaternion.Euler(-defaultRotation);
            mainCard.localPosition = new Vector3(defaultPosition.x, 1.2f, -11f);
            mainCard.localScale = Vector3.one * 1.1f;
        }

        private void OnMouseDrag()
        {
            isDragging = true;

            mousePosition = MouseUtility.GetMouseWorldPosition();
            mousePosition.z = mainCard.position.z;
            mainCard.position = mousePosition;
        }

        private void OnMouseUp()
        {
            Collider2D targetLandscape = Physics2D.OverlapPoint(MouseUtility.GetMouseWorldPosition(), landscapeMask);
            
            if (targetLandscape == null)
            {
                SetDefaultTransform();
                return;
            }

            BaseLandscapeController landscapeController = targetLandscape?.GetComponent<BaseLandscapeController>();

            if (cardData.applicableLandscapes.IndexOf(landscapeController.LandscapeType) == -1)
            {
                SetDefaultTransform();
            }
            else
            {
                landscapeController.OnCardApply(cardData);
                HandController.Instance.RemoveCard(this);
            }
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
            isDragging = false;

            mainCard.localScale = Vector3.one;
            mainCard.localRotation = Quaternion.Euler(Vector3.zero);
            mainCard.localPosition = defaultPosition;
        }

        private void OnDestroy()
        {

        }
    }
}
