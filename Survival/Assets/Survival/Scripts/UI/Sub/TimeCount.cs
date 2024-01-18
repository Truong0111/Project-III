using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    [Title("Event")] [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent resumeGameEvent;
    [SerializeField] private VoidEvent menuEvent;

    [Title("Ref")] [SerializeField] private TextMeshProUGUI timeCountText;

    private static float TimeTarget => GameManager.Instance.TimeTarget;
    private bool _isPaused = false;
    private Coroutine _coroutine;

    private void Awake()
    {
        startGameEvent.Register(StartCountTime);
        stopGameEvent.Register(PauseCountTime);
        pauseGameEvent.Register(PauseCountTime);
        winEvent.Register(StopCountTime);
        loseEvent.Register(StopCountTime);
        resumeGameEvent.Register(ResumeCountTime);
        menuEvent.Register(BackToMenu);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        startGameEvent.Unregister(StartCountTime);
        stopGameEvent.Unregister(PauseCountTime);
        pauseGameEvent.Unregister(PauseCountTime);
        winEvent.Unregister(StopCountTime);
        loseEvent.Unregister(StopCountTime);
        resumeGameEvent.Unregister(ResumeCountTime);
    }

    private void PauseCountTime() => _isPaused = true;
    private void ResumeCountTime() => _isPaused = false;

    private void BackToMenu()
    {
        StopCountTime();
        gameObject.SetActive(false);
    }

    private void StopCountTime()
    {
        _isPaused = true;
        if (_coroutine != null) StopCoroutine(_coroutine);
    }

    private void StartCountTime()
    {
        gameObject.SetActive(true);
        timeCountText.text = TimeFormat(0f);
        _coroutine = StartCoroutine(MTime.CountUp(TimeTarget, UpdateCountText, CountDone, () => _isPaused));
    }

    private void UpdateCountText(int counter)
    {
        timeCountText.text = TimeFormat(counter);
    }

    private static string TimeFormat(float timeInSeconds)
    {
        var minutes = Mathf.FloorToInt(timeInSeconds / 60);
        var seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return $"{minutes:00}:{seconds:00}";
    }

    private void CountDone() => winEvent.Raise();
}

public static class MTime
{
    public static IEnumerator CountDown(float duration, Action<int> remainTick = null, Action onEnd = null
        , Func<bool> isPaused = null)
    {
        var remainingTime = (int)duration;
        while (remainingTime > 0)
        {
            if (isPaused != null && isPaused())
            {
                yield return null;
            }
            else
            {
                remainTick?.Invoke(remainingTime);
                yield return new WaitForSeconds(1.0f);
                remainingTime--;

                if (remainingTime == 0) remainTick?.Invoke(remainingTime);
            }
        }

        onEnd?.Invoke();
    }

    public static IEnumerator CountUp(float target, Action<int> currentTick = null, Action onEnd = null
        , Func<bool> isPaused = null)
    {
        var currentTime = 0;
        while (currentTime < target)
        {
            if (isPaused != null && isPaused())
            {
                yield return null;
            }
            else
            {
                currentTick?.Invoke(currentTime);
                yield return new WaitForSeconds(1.0f);
                currentTime++;

                if (currentTime == (int)target) currentTick?.Invoke(currentTime);
            }
        }

        onEnd?.Invoke();
    }
}