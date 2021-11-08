using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _radiusCollider;

    private SphereCollider collider;

    private void Awake()
    {
        collider = GetComponent<SphereCollider>();
        collider.radius = _radiusCollider;
    }
}
