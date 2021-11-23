using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    private GameControlManager gm;
    private bool isMoving = false;

    private void Start() {
        gm = GameControlManager.instance;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Grounded", true);
        animator.SetFloat("MoveSpeed", 0);
    }

    private void Update() {
        if (Vector3.Distance(gm.ballBehaviour.transform.position, transform.position) < 10) {
            if (!isMoving) {
                navMeshAgent.enabled = true;
                animator.SetFloat("MoveSpeed", 3);
            }
            navMeshAgent.destination = gm.ballBehaviour.transform.position;
        }else if (isMoving) {
            navMeshAgent.enabled = false;
            animator.SetFloat("MoveSpeed", 0);
        }
    }
}
