using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class AdministrativeController : BaseLandscapeController
    {
        protected float corruption
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }

        protected override void HandleUpdate(float currentTime)
        {
            
        }
    }
}
