using System;
using UnityEngine;
using UnityEngine.UI;

public class Bonuses : MonoBehaviour
{
    public static Func<int> OnBonusSelect;
    public static Action<int,int,Button> OnBonusReady;

    [SerializeField] private int price;
    private Button bonusIcon;
    [SerializeField] private int bonusNumber;
    public void SelectBonus()
    {
        if(OnBonusSelect?.Invoke()>= price)
        {
            bonusIcon.interactable = false;
            OnBonusReady?.Invoke(bonusNumber,price, bonusIcon);
        }
       
    }

    private void Start()
    {
        bonusIcon = GetComponent<Button>();
    }


}
