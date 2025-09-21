using UnityEngine;
using UnityEngine.UI;

public class RingCounter : MonoBehaviour
{
    public int throwCount = 0;
    public Slider visuals;
    public GameObject resultScreen;

    void Start()
    {
        visuals.maxValue = 5;
        visuals.value = throwCount;

        resultScreen.SetActive(false);
    }

    public void ThrowRing()
    {
        throwCount += 1;
        visuals.value = throwCount;
    }

    void Update()
    {
        if (throwCount == 5)
        {
            resultScreen.SetActive(true);
        }
    }
}
