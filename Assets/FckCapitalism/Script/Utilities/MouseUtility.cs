using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class MouseUtility
    {
        public static Vector2 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f;

            return mouseWorldPosition;
        }
    }
}