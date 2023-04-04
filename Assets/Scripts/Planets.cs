using UnityEngine;

public class Planets : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;

    private void FixedUpdate()
    {
        transform.Rotate(speed * Time.deltaTime * direction);
    }
}
