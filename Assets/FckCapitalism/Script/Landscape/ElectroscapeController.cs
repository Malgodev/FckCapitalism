using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class ElectroscapeController : BaseLandscapeController
    {
        protected float overload
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }


    }
}
