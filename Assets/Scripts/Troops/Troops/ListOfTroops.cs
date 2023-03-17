using System.Collections.Generic;
using UnityEngine;

public class ListOfTroops : MonoBehaviour
{
    private List<Transform> numberOfTroops =new();

    private void OnEnable()
    {
        EnemyTroops.OnTargetFind += GetRandomTroop;
        PlayerTroops.OnTargetDead += DeleteTroopFromList;
    }
    private void OnDisable()
    {
        EnemyTroops.OnTargetFind -= GetRandomTroop;
        PlayerTroops.OnTargetDead -= DeleteTroopFromList;
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

    public void DeleteTroopFromList(Transform troopToDelete)
    {
        numberOfTroops.Remove(troopToDelete);
    }
}
