using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour {

    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public bool isBallHolder = false;
    private bool isMoving = false;
    private GameObject ball;
    private float moveSpeed = 5;
    private float startPosX = 0;
    
    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Grounded", true);
        ball = GameControlManager.instance.ballBehaviour.gameObject;
    }

    private void Update() {
        if (!isBallHolder) {
            // its not holding ball and close to ball
            if (Vector3.Distance(ball.transform.position, transform.position) < 10 && !GameControlManager.instance.isBallOnPlayer) {
                if (!isMoving) {
                    StartCatherPlayer();
                }
                // set ball position as target
                navMeshAgent.destination = ball.transform.position;
            }
            // its not close to ball and its moving
            else if (isMoving) {
                StopCatherPlayer();
            }
        }
    }

    private void StartCatherPlayer() {
        isMoving = true;
        navMeshAgent.enabled = true;
        animator.SetFloat("MoveSpeed", 5);
    }

    private void StopCatherPlayer(bool isCached = false) {
        isBallHolder = isCached;
        animator.SetFloat("MoveSpeed", 0);
        navMeshAgent.enabled = false;
        isMoving = false;
    }
    
    public void StartHolderMovement() {
        startPosX = Input.mousePosition.x;
        navMeshAgent.enabled = true;
    }

    public void MoveHolder() {
        animator.SetFloat("MoveSpeed", 5);
        transform.rotation = Quaternion.Euler(0, ((Input.mousePosition.x - startPosX) / Screen.width)* 30.0f, 0);
        navMeshAgent.destination = transform.position + transform.forward;
    }

    public void EndHolderMovement() {
        isBallHolder = false;
        animator.SetFloat("MoveSpeed", 0);
        navMeshAgent.enabled = false;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("ball")) {
            GameControlManager.instance.BallCached(this);
            StopCatherPlayer(true);
        }else if (other.transform.CompareTag("enemy") && isBallHolder) {
            GameManager.instance.GameEndFail();
        }
    }
}
