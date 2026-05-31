using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 60;
    [SerializeField] private bool isTimerRunning = false;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Events")]
    public UnityEvent onTimerComplete;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            isTimerRunning = false;
            UpdateTimerDisplay();
            OnTimerEnd();
        }
    }

    public void StartTimer() => isTimerRunning = true;
    public void PauseTimer() => isTimerRunning = false;

    public void ResetTimer(float newTime)
    {
        timeRemaining = newTime;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timeRemaining;
    }

    private void OnTimerEnd()
    {
        Debug.Log("Timer has finished!");
        onTimerComplete?.Invoke();
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
}
