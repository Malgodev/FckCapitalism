using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class ForestController : BaseLandscapeController
    {
        protected float treeDensity
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}