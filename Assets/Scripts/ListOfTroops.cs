using System.Collections.Generic;
using UnityEngine;

public class ListOfTroops : MonoBehaviour
{
    public List<Transform> numberOfTroops;

    private void OnEnable()
    {
        EnemyTroops.OnTargetFind += GetRandomTroop;
    }
    private void OnDisable()
    {
        EnemyTroops.OnTargetFind -= GetRandomTroop;
    }

    void Start()
    {
        foreach (Transform troop in transform)
        {
            numberOfTroops.Add(troop);
        }
    }

    public Transform GetRandomTroop()
    {
        return numberOfTroops[Random.Range(0,numberOfTroops.Count)];
    }

}
