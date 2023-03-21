using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Reinforcement : MonoBehaviour
{


    private TMP_Text text;

    private int reinforcementPoints=1000;

    private int selectedBonus = -1;
    private int bonusPrice;
    private Button buttonSelected;

    [SerializeField] private GameObject[] bonuses;
    private void OnEnable()
    {
        EnemyTroops.OnDeath += Increase;
        Bonuses.OnBonusSelect += GetreinforcementPoints;
        Bonuses.OnBonusReady += SelectedBonus;
    }
    private void OnDisable()
    {
        EnemyTroops.OnDeath -= Increase;
        Bonuses.OnBonusSelect -= GetreinforcementPoints;
        Bonuses.OnBonusReady -= SelectedBonus;
    }

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = reinforcementPoints.ToString();
    }

    private void Increase(int points)
    {
        reinforcementPoints += points;
        text.text = reinforcementPoints.ToString();
    }
    private int GetreinforcementPoints()
    {
        return reinforcementPoints;
    }

    private void SelectedBonus(int bonusNubmer, int price, Button button)
    {
        selectedBonus = bonusNubmer;
        bonusPrice = price;
        buttonSelected = button;
    }

    public void UseBonus(InputAction.CallbackContext context)
    {
        if (selectedBonus != -1)
        {
            Vector3 positionToSpawn = context.ReadValue<Vector2>();
            positionToSpawn.z =7; //takes camera z position
            positionToSpawn = Camera.main.ScreenToWorldPoint(positionToSpawn);
            positionToSpawn.y += 10;
 
            Instantiate(bonuses[selectedBonus], positionToSpawn, Quaternion.identity);          
            selectedBonus = -1;
            reinforcementPoints -= bonusPrice;
            text.text = reinforcementPoints.ToString();
            buttonSelected.interactable = true;

        }      
    }
}
