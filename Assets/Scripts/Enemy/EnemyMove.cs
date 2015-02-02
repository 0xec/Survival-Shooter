﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{

    private Transform playerTransform;
    private NavMeshAgent nav;
    private Animator animator;
    private EnemyHealth healthComponment;
    private bool move = true;

    // Use this for initialization
    void Start() {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        healthComponment = GetComponent<EnemyHealth>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate() {

        float dis = Vector3.Distance(transform.position, playerTransform.position);
        move = dis > 2.0f;

        if (healthComponment.health > 0 && move) {
            nav.enabled = true;
            nav.SetDestination(playerTransform.position);
        } else  {
            nav.enabled = false;
        }
        animator.SetBool("IsMoving", move);
    }
}
