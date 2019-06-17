using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private GameManager gameManager;
    private string scoretext = "<color=#FFFFFF> You finished the game with score of <color=#ffffff> {0} <color=#FFFFFF> points.";

    private Action onUpdate = delegate { };

    public void Display()
    {
        textObject.text = string.Format(scoretext, gameManager.counterPointsOnGUI);
        gameManager.DisableCounter();
        parentCanvas.SetActive(true);
        Time.timeScale = 0;
        Lean.Touch.LeanTouch.OnFingerDown += (Lean.Touch.LeanFinger finger) => { onUpdate += returnTotitleScreen; };
    }

    private void returnTotitleScreen()
    {
        Time.timeScale = 1;
        Lean.Touch.LeanTouch.OnFingerDown -= (Lean.Touch.LeanFinger finger) => { onUpdate += returnTotitleScreen; };
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        onUpdate();
    }
}