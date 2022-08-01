using NaughtyAttributes;
using Supyrb;
using UnityEngine;

public class PlayerCollisionTrackerComponent : MonoBehaviour
{
    [SerializeField] [Tag] private string PlayerTag;

    private Signal<GameObject> onFacedPlayer;

    private void Start()
    {
        onFacedPlayer = Signals.Get<OnFacedPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            onFacedPlayer?.Dispatch(gameObject);
        }
    }
}