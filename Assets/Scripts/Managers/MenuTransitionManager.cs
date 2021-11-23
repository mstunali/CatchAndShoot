using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransitionManager : MonoBehaviour {
    public static MenuTransitionManager instance;

    void Awake() {
        if (instance != null) {
            DestroyImmediate(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void GameToGameEnd() {
        StartCoroutine(SceneSwitch("game", "gameEnd"));
    }
    
    public void GameEndToGame() {
        StartCoroutine(SceneSwitch("gameEnd", "game"));
    }
    
    // Can be written with additive overlay animation scene. 
    IEnumerator SceneSwitch(string from, string to) {
        AsyncOperation load = SceneManager.UnloadSceneAsync(from);
        yield return load;
        SceneManager.LoadSceneAsync(to, LoadSceneMode.Single);
    }
}
