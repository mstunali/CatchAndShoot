using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlManager : MonoBehaviour {
    public static GameControlManager instance;
    public PlayerBehaviour ballHolderPlayer;
    public BallBehaviour ballBehaviour;
    public bool isBallOnPlayer = true;
    public int ballThrowForce = 1000;
    void Awake() {
        if (instance != null) {
            DestroyImmediate(gameObject);
        }
        else {
            instance = this;
        }
    }
    
    private void Update() {
        if (isBallOnPlayer) {
            if (Input.GetMouseButtonDown(0)) {
                ballHolderPlayer.StartHolderMovement();
            }
            
            if (Input.GetMouseButton(0)) {
                ballHolderPlayer.MoveHolder();
            }

            if (Input.GetMouseButtonUp(0)) {
                isBallOnPlayer = false;
                ballBehaviour.Throw();
                ballHolderPlayer.EndHolderMovement();
            }
        }
    }

    public void BallCached(PlayerBehaviour playerBehaviour) {
        ballHolderPlayer = playerBehaviour;
        isBallOnPlayer = true;
        ballBehaviour.Cached();
    }

    
}
