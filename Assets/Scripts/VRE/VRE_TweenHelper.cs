using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_TweenHelper
{

    public static IEnumerator LerpWithEasing(GameObject g, Transform start, Transform end, float time, string ease, bool destroy)
    {

        float elapsedTime = 0;

        Vector3 startPos = start.position;
        Vector3 startScale = start.localScale;
        Quaternion startRot = start.rotation;

        Vector3 endPos = end.position;
        Vector3 endScale = end.localScale;
        Quaternion endRot = end.rotation;

        while (elapsedTime < time)
        {

            // this lerps transform Vector3
            float t = elapsedTime / time;
            // easing function - this can be tweaked
            // t = t * t * t * (t * (6f * t - 15f) + 10f);

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            g.transform.position = Vector3.Lerp(startPos, endPos, t);
            g.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            g.transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (destroy)
            GameObject.Destroy(g);

    }

    public static IEnumerator LerpPositionWithEasing(GameObject g, Vector3 start, Vector3 end, float time, string ease, bool destroy)
    {

        float elapsedTime = 0;

        Vector3 startPos = start;

        Vector3 endPos = end;

        while (elapsedTime < time)
        {

            // this lerps transform Vector3
            float t = elapsedTime / time;
            // easing function - this can be tweaked
            // t = t * t * t * (t * (6f * t - 15f) + 10f);

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            g.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (destroy)
            GameObject.Destroy(g);

    }

    public static IEnumerator LerpLocalPositionWithEasing(GameObject g, Vector3 start, Vector3 end, float time, string ease, bool destroy)
    {

        float elapsedTime = 0;

        Vector3 startPos = start;

        Vector3 endPos = end;

        while (elapsedTime < time)
        {

            // this lerps transform Vector3
            float t = elapsedTime / time;
            // easing function - this can be tweaked
            // t = t * t * t * (t * (6f * t - 15f) + 10f);

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            g.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (destroy)
            GameObject.Destroy(g);

    }

    public static IEnumerator LerpScaleWithEasing(GameObject g, Vector3 start, Vector3 end, float time, string ease, bool destroy)
    {

        float elapsedTime = 0;

        Vector3 startPos = start;

        Vector3 endPos = end;

        while (elapsedTime < time)
        {

            // this lerps transform Vector3
            float t = elapsedTime / time;
            // easing function - this can be tweaked
            // t = t * t * t * (t * (6f * t - 15f) + 10f);

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            g.transform.localScale = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (destroy)
            GameObject.Destroy(g);

    }

    public static IEnumerator ColorFade(GameObject g, Material to, float time, string ease)
    {

        // Enable Instancing
        to.enableInstancing = true;

        // elapsedTime
        float elapsedTime = 0;

        // get the starting material and color
        Renderer r = g.GetComponent<Renderer>();
        Material m = r.material;

        Color startColor = m.GetColor("_Color");
        Color endColor = to.color;

        while (elapsedTime < time)
        {

            // this lerps color
            float t = elapsedTime / time;

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            // Debug.Log (currentColor.ToString());
            m.SetColor("_Color", currentColor);
            yield return null;


        }
    }

    public static IEnumerator ColorFade(GameObject g, Color c, float time, string ease)
    {

        // Debug.Log ("ColorFade Called");

        // elapsedTime
        float elapsedTime = 0;

        // get the starting material and color
        Renderer r = g.GetComponent<Renderer>();
        Material m = r.material;

        Color startColor = m.GetColor("_Color");
        Color endColor = c;

        while (elapsedTime < time)
        {

            // this lerps color
            float t = elapsedTime / time;

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            // Debug.Log (currentColor.ToString());
            m.SetColor("_Color", currentColor);
            yield return null;

        }

    }


    public static IEnumerator ColorFade(Material m, Color c, float time, string ease)
    {

        // Debug.Log ("ColorFade Called");

        // elapsedTime
        float elapsedTime = 0;

        Color startColor = m.GetColor("_Color");
        Color endColor = c;

        while (elapsedTime < time)
        {

            // this lerps color
            float t = elapsedTime / time;

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            // Debug.Log (currentColor.ToString());
            m.SetColor("_Color", currentColor);
            yield return null;

        }

    }

    public static IEnumerator OpacityFade(GameObject g, float targetOpacity, float time, string ease, string property)
    {

        Renderer r = g.GetComponent<Renderer>();
        r.material.enableInstancing = true;
        Material m = r.material;

        Debug.Log ("OpacityFade Called for " + g.name);

        // elapsedTime
        float elapsedTime = 0;

        Color startColor = m.GetColor(property);
        Color endColor = new Color(m.GetColor(property).r, m.GetColor(property).g, m.GetColor(property).b, targetOpacity);

        while (elapsedTime < time)
        {

            // this lerps color
            float t = elapsedTime / time;

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            // Debug.Log (currentColor.ToString());
            m.SetColor(property, currentColor);
            yield return null;

        }

    }


    public static IEnumerator ColorFade(Material from, Material to, float time, string ease, string property)
    {

        // Debug.Log ("ColorFade Called");

        // elapsedTime
        float elapsedTime = 0;

        Color startColor = from.GetColor(property);
        Color endColor = to.GetColor(property);

        while (elapsedTime < time)
        {

            // this lerps color
            float t = elapsedTime / time;

            switch (ease)
            {
                case "Back":
                    t = Easing.Back.InOut(t);
                    break;
                case "Bounce":
                    t = Easing.Bounce.InOut(t);
                    break;
                case "Circular":
                    t = Easing.Circular.InOut(t);
                    break;
                case "Cubic":
                    t = Easing.Cubic.InOut(t);
                    break;
                case "Elastic":
                    t = Easing.Elastic.InOut(t);
                    break;
                case "Exponential":
                    t = Easing.Exponential.InOut(t);
                    break;
                case "Linear":
                    t = Easing.Linear(t);
                    break;
                case "Quadratic":
                    t = Easing.Quadratic.InOut(t);
                    break;
                case "Quartic":
                    t = Easing.Quartic.InOut(t);
                    break;
                case "Quintic":
                    t = Easing.Quintic.InOut(t);
                    break;
                default:
                    t = Easing.Cubic.InOut(t);
                    break;
            }

            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            // Debug.Log (currentColor.ToString());
            from.SetColor(property, currentColor);
            yield return null;

        }

    }



}
