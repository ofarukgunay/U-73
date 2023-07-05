using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLM, playerLM;

    //Patrolling
    public Vector3 walkTargetPos;
    bool walkTargetSet = false;
    public float patrolRange;

    //Attacking
    public float attackPauseTime;
    bool isAttacking = false;

}
