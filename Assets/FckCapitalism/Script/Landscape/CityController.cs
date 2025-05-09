using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class CityController : BaseLandscapeController
    {
        protected float dystopia
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}
