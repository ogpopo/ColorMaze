using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal oterTeleport;

    public Portal OterTeleport => oterTeleport;
}