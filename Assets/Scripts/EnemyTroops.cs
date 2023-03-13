using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyTroops : Troops
{
    public static Func<Transform> OnTargetFind;

    private NavMeshAgent agent;
    private Transform target;
    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    private void SetDestinationTroop(Transform playerTrops)
    {
        target = playerTrops;
    }

    private void OnEnable()
    {
        SetDestinationTroop(OnTargetFind?.Invoke());
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }
}
