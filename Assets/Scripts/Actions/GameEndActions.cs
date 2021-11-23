using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndActions : MonoBehaviour {
    public void ToGame() {
        MenuTransitionManager.instance.GameEndToGame();
    }
}
