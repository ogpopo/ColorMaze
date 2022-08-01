using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Turn turnOnLevel;

    public Turn TurnOnLevel => turnOnLevel;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, (float)turnOnLevel, transform.rotation.z);
    }
}