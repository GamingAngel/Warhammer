using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : PlayerTroops
{
    public static Action<int> OnLose;
    protected override void Die()
    {
        OnLose?.Invoke(SceneManager.GetActiveScene().buildIndex);
        base.Die();
    }
}
