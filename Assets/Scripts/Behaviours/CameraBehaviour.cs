using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public GameObject player;

    private void LateUpdate() {
        var gm = GameControlManager.instance;
        if (gm.isBallOnPlayer) {
            transform.position = gm.ballHolderPlayer.transform.position + new Vector3(0,5,-5);
        }
        else {
            transform.position = gm.ballBehaviour.transform.position + new Vector3(0,5,-5);
        }
    }
}
