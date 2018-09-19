using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private string _fireCommand;

    [SerializeField, Range(0.0f, 360.0f)]
    private float _firingAngle;

    [SerializeField]
    private float _projectileSpeed = 5.0f;

    [SerializeField]
    private TextMeshPro _text;

    void Start ()
    {
        TwitchCommandManager.Instance.TwitchCommandRegister += HandleTwitchCommand;
        if (_text != null)
        {
            _text.text = _fireCommand;
        }
    }

    private void HandleTwitchCommand(string message)
    {
        if (message.Equals(_fireCommand))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        var projectile = GameObject.Instantiate(PrefabManager.Instance.StandardEnemyProfectile, transform.position, transform.rotation);
        var projectileScript = projectile.GetComponent<ProjectileBehaviour>();

        projectileScript.Fire(Vector2.up, _projectileSpeed);
    }
}
