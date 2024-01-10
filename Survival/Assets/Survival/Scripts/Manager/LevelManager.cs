using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private VoidEvent startLevelEvent;
    [SerializeField] private VoidEvent backToMenuEvent;
    [SerializeField] private VoidEvent loadLevelEvent;

    public AsyncOperation LoadSceneAsync { get; set; }

    private void Awake()
    {
        loadLevelEvent.Register(StartLevel);
        backToMenuEvent.Register(BackToMenu);
    }

    private void OnDisable()
    {
        loadLevelEvent.Unregister(StartLevel);
        backToMenuEvent.Unregister(BackToMenu);
    }

    private void StartLevel()
    {
        StartCoroutine(LoadScene());
    }

    private void BackToMenu()
    {
        StartCoroutine(UnloadScene());
    }

    private IEnumerator LoadScene()
    {
        LoadSceneAsync = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        yield return new WaitUntil(() => LoadSceneAsync.isDone);
    }
    
    private IEnumerator UnloadScene()
    {
        var scene = SceneManager.GetSceneByBuildIndex(1);
        if (!scene.isLoaded) yield break;
        LoadSceneAsync = SceneManager.UnloadSceneAsync(1,UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        yield return new WaitUntil(() => LoadSceneAsync.isDone);
    }

    public void MoveObjectToScene(GameObject obj)
    {
        var scene = SceneManager.GetSceneByBuildIndex(1);
        if (!scene.isLoaded) return;
        SceneManager.MoveGameObjectToScene(obj, scene);
    }
}