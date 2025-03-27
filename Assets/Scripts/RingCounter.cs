using UnityEngine;
using UnityEngine.UI;

public class RingCounter : MonoBehaviour
{
    public int throwLimit = 5;
    public Slider visuals;
    public GameObject gameOverScreen;

    void Start()
    {
        visuals.maxValue = throwLimit;
        visuals.value = throwLimit;
    }

    public void ThorwRing()
    {
        throwLimit -= 1;
        visuals.value = throwLimit;
    }

    void Update()
    {
        if (throwLimit == 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
