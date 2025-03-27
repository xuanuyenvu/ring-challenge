using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject ringPrefab;
    private Ring currentRing = null;
    public bool isCoroutineRunning = false;
    public UnityEvent onRingCounterUpdate;

    void Start()
    {
        CreateNewRing();
    }

    private void CreateNewRing()
    {
        GameObject ringObject = Instantiate(ringPrefab, new Vector3(0, -5.3f, 0), Quaternion.identity);
        currentRing = ringObject.GetComponent<Ring>();
    }

    public void ThrowRing(Vector3 positionCup)
    {
        isCoroutineRunning = true;
        StartCoroutine(ThrowRingAndCreateNew(positionCup));
    }

    private IEnumerator ThrowRingAndCreateNew(Vector3 positionCup)
    {
        // https://www.youtube.com/watch?v=7RBI9mb8s3E
        yield return StartCoroutine(currentRing.ThrowRingCoroutine(positionCup)); 

        yield return new WaitForSeconds(0.5f); 

        currentRing = null;
        onRingCounterUpdate.Invoke();
        CreateNewRing();
        isCoroutineRunning = false;
    }
}
