using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyTroops : Troops
{
    public static Func<Transform> OnTargetFind;

    private NavMeshAgent agent;
    private Transform target;

    protected override void Die()
    {
        Debug.Log("Enemy");
        base.Die();
    }
    private void SetDestinationTroop()
    {
        target = OnTargetFind?.Invoke();
    }

    private void OnEnable()
    {
        SetDestinationTroop();
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
        Attack();
        transform.LookAt(target.position);
    }
}
