using System.Collections;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public AnimationCurve curve;
    private float minSize = 0.1f;
    private Vector3 offset = new Vector3(0, 1f, 0);

    public IEnumerator ThrowRingCoroutine(Vector3 positionCup)
    {
        Vector3 endPosition = positionCup + offset;
    
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, endPosition, curve.Evaluate(t));
            transform.localScale = Vector3.one * minSize * curve.Evaluate(1 - t);
            
            yield return null;
        }

        Destroy(gameObject);
    }
}
