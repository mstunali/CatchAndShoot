using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public int levelCount = 0;
    public bool isLastLevelSuccess = false;
    
    void Awake() {
        if (instance != null) {
            DestroyImmediate(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void GameEndFail() {
        isLastLevelSuccess = false;
        MenuTransitionManager.instance.GameToGameEnd();
    }

    public void GameEndSuccess() {
        isLastLevelSuccess = true;
        levelCount++;
        MenuTransitionManager.instance.GameToGameEnd();
    }
}
