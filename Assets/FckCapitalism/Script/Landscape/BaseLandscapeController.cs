using Card;
using UnityEngine;

namespace Landscape
{
    public abstract class BaseLandscapeController : MonoBehaviour
    {
        protected virtual void Start()
        {

        }

        protected virtual void OnCardStartHover()
        {

        }

        public virtual void OnCardApply(BaseCardController card)
        {
            Debug.Log(card.name + " applied to " + gameObject.name);
        }

        protected virtual void OnCardEndHover()
        {

        }
    }
}