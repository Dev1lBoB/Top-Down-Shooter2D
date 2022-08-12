using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static IEnumerator FlashEffect(this Renderer rend, float totalTime, float blinkTime)
    {
        float endTime = Time.time + totalTime;
        while (Time.time < endTime)
        {
            rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(blinkTime);
        }
    }
}
