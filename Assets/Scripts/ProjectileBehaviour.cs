using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void Fire(Vector2 direction, float projectileSpeed)
    {
        _rb.velocity = direction.normalized * projectileSpeed;
    }
}
