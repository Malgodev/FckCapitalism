using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Malgo.FckCapitalism.Landscape
{
    public class WastelandController : BaseLandscapeController
    {
        protected float decay
        {
            get => specialStat;
            set
            {
                specialStat = value;
            }
        }
    }
}