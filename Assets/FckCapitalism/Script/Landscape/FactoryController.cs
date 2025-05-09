using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class FactoryController : BaseLandscapeController
    {
        protected float automation
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}
