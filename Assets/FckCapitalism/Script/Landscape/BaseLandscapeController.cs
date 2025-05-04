using Card;
using UnityEngine;

namespace Landscape
{
    public enum LandscapeType
    {
        Electronic,
        Port,
        Administrative,
        Factory,
        Mountain,
        City,
        Wasteland,
        Jungle,
        Slum,
    }

    public class BaseLandscapeController : MonoBehaviour
    {
        [SerializeField] private LandscapeType landscapeType;

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