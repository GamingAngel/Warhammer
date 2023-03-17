using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Flag : MonoBehaviour
{
    private const float HEIGHTTOLIFT = -0.22f;
    private const float STARTPOSITION = -1.35f;

    public static Action<int> OnWin;

    private float speed;
    [SerializeField] private float timeToDefend;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
            if(transform.position.y >= HEIGHTTOLIFT)
            {
                OnWin?.Invoke(SceneManager.GetActiveScene().buildIndex+1);
                GetComponent<Collider>().enabled = false;
                print("win");
            }
        }     
    }

    private void Start()
    {
        speed = Math.Abs((STARTPOSITION-HEIGHTTOLIFT) / timeToDefend);
    }
}
