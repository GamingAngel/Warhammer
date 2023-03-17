using UnityEngine;
using TMPro;
public class Reinforcement : MonoBehaviour
{
    private TMP_Text text;

    private int reinforcementPoints;

    private void OnEnable()
    {
        EnemyTroops.OnDeath += Increase;
    }
    private void OnDisable()
    {
        EnemyTroops.OnDeath -= Increase;
    }

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = reinforcementPoints.ToString();
    }

    public void Increase(int points)
    {
        reinforcementPoints += points;
        text.text = reinforcementPoints.ToString();
    }



}
