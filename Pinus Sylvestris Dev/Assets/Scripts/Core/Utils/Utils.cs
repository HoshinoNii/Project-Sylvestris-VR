using System.Collections;
using UnityEngine;

namespace Core.Utils {
    public static class Utils  {
        public static IEnumerator Fade(float time, Material material, bool fadeOut)
        {
            // Fade to transparent
            while (fadeOut ? material.color.a > 0.0f : material.color.a < 1.0f)
            {
                material.color = new Color(material.color.r, material.color.g, material.color.b,
                    material.color.a - Time.deltaTime / time);
                yield return null;
            }
        }
    }
}