using System.Collections.Generic;
using UnityEngine;

public class ListOfTroops : MonoBehaviour
{
    private List<Transform> numberOfTroops =new();

    private void OnEnable()
    {
        EnemyTroops.OnTargetFind += GetRandomTroop;
        PlayerTroops.OnTargetDead += DeleteTroopFromList;
        PlayerTroops.OnTargetSpawn += AddTroop;
    }
    private void OnDisable()
    {
        EnemyTroops.OnTargetFind -= GetRandomTroop;
        PlayerTroops.OnTargetDead -= DeleteTroopFromList;
        PlayerTroops.OnTargetSpawn -= AddTroop;
    }

    private void AddTroop(Transform troop) => numberOfTroops.Add(troop);


    private Transform GetRandomTroop()
    {
        return numberOfTroops[Random.Range(0,numberOfTroops.Count)];
    }

    private void DeleteTroopFromList(Transform troopToDelete) => numberOfTroops.Remove(troopToDelete);
}
