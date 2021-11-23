using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndButtonBehaviour : MonoBehaviour {
    public TextMeshProUGUI text;
    private void Start() {
        if (GameManager.instance.isLastLevelSuccess) {
            text.text = "Next Level";
        }
        else {
            text.text = "Retry";
        }
    }
}
