using UnityEngine;

public class EnableTroops : MonoBehaviour
{
    [SerializeField] private GameObject troops;

    private void Start()
    {
        troops.SetActive(true);
    }
}
