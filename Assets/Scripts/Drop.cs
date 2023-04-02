using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject[] troop;
    [SerializeField] private Transform[] positions;

    private void Start()
    {
        Destroy(gameObject,7);
        Invoke(nameof(SpawnTroops), 1.6f);
    }

    private void SpawnTroops()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(troop[i], positions[i].position, positions[i].rotation);
        }
    }
}
