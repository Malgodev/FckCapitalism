using DG.Tweening;
using UnityEngine;

namespace Malgo.FckCapitalism.Card
{
    public class HandAnimation : MonoBehaviour
    {
        private float defaultY;
        private float defaultScale;

        [Header("On Hover")]
        [SerializeField] private float hoverScale = 1.2f;
        [SerializeField] private float hoverY = -17f;
        [SerializeField] private float hoverDuration = 0.5f;

        Sequence hoverSequence;

        private void Start()
        {
            defaultY = transform.position.y;
            defaultScale = transform.localScale.x;
        }

        private void OnMouseEnter()
        {
            HoverAnimation(hoverY, hoverScale);
        }

        private void OnMouseExit()
        {
            HoverAnimation(defaultY, defaultScale);
        }

        private void HoverAnimation(float targetYPosition, float targetScale)
        {
            hoverSequence?.Kill();

            hoverSequence = DOTween.Sequence();

            hoverSequence
                .Append(
                transform.DOLocalMoveY(
                    targetYPosition,
                    hoverDuration)
                .SetEase(Ease.OutQuart))
                .Join(
                transform.DOScale(
                    new Vector3(targetScale, targetScale, targetScale),
                    hoverDuration)
                .SetEase(Ease.OutQuart));

            hoverSequence.Play();
        }
    }
}
