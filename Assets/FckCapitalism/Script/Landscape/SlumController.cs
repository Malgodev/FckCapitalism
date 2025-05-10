using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class SlumController : BaseLandscapeController
    {
        protected float instability
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