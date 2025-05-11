using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class Seaport : BaseLandscapeController
    {
        protected float contraband
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}
