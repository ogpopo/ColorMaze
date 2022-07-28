using UnityEngine;
using Kuhpik;

public class CellTrackerComponent : MonoBehaviour
{
    [SerializeField] Bootstrap bootstrap;

    private void Awake()
    {
        bootstrap = GameObject.FindGameObjectWithTag("Bootstrap").GetComponent<Bootstrap>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (bootstrap.GameData.CurrentCell == hit.transform)
                return;

            bootstrap.GameData.CurrentCell = hit.transform;
        }
    }
}