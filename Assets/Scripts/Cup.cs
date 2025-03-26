using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Cup : MonoBehaviour
{
    public TextMeshProUGUI successText;
    public TextMeshProUGUI failureText;
    public AnimationCurve curve;
    public UnityEvent onScoreUpdated;    
    public GameManager gameManager;

    private SpriteRenderer sr;

    void Start()
    {
        successText.gameObject.SetActive(false);
        failureText.gameObject.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameManager.isCoroutineRunning == false)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousePos))
            {
                ShowResultText();
            }
        }
    }

    private void ShowResultText()
    {
        if (IsSecret() == true)
        {
            DisplayAnimatedText(successText);
            gameManager.ThrowRing(transform.position);
            onScoreUpdated.Invoke();
        }
        else
        {
            DisplayAnimatedText(failureText);
            gameManager.ThrowRing(transform.position);
        }
    }

    private bool IsSecret()
    {
        int result = Random.Range(0, 100);
        return result < 10; 
    }

    private void DisplayAnimatedText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        StartCoroutine(ShowText(text));
    }

    private IEnumerator ShowText(TextMeshProUGUI text)
    {
        float t = 0f;
        while (t < 0.4f)
        {
            t += Time.deltaTime;
            text.transform.localScale = Vector3.one * curve.Evaluate(t);
            yield return null;
        }

        t = 0f;
        while (t < 0.4f)
        {
            t += Time.deltaTime;
            text.transform.localScale = Vector3.one * curve.Evaluate(1 - t);
            yield return null;
        }

        text.gameObject.SetActive(false);
    }
}
