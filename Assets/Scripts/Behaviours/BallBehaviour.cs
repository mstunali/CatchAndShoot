using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
    private bool isFailed = false;
    private GameControlManager gm;
    
    private void Start() {
        gm = GameControlManager.instance;
    }

    private void LateUpdate() {
        if (GameControlManager.instance.isBallOnPlayer) {
            transform.position = gm.ballHolderPlayer.transform.position + new Vector3(0.5f,0.75f,0.5f);
        }

        if (!isFailed && transform.position.y < -5) {
            isFailed = true;
            GameManager.instance.GameEndFail();
        }
    }

    public void Throw() {
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(gm.ballHolderPlayer.transform.forward * gm.ballThrowForce);
        GetComponent<SphereCollider>().isTrigger = false;
    }

    public void Cached() {
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        GetComponent<SphereCollider>().isTrigger = true;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("finishWall")) {
            GameManager.instance.GameEndSuccess();
        }else if (other.transform.tag == "enemy") {
            GameManager.instance.GameEndFail();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("enemy")) {
            GameManager.instance.GameEndFail();
        }
    }
}
