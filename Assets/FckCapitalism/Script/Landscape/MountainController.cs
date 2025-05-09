using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class MountainController : BaseLandscapeController
    {
        protected float oreDensity
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}
