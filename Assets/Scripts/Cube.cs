using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Explosion))]
public class Cube : MonoBehaviour
{
    private const float DividerHalf = 2;

    private Explosion _explosion;

    [SerializeField] private bool _isGuaranteedSpawn = false;
    [SerializeField] private float _chanceSpawn = 1f;

    public event Action<Cube> OnBeforeDestroy;
    public event Action<Cube> OnClicked;

    private void Start()
    {
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseDown()
    {
        float roll = UnityEngine.Random.Range(0f, 1f);

        if (_isGuaranteedSpawn == true)
        {
            OnClicked?.Invoke(this);
        }
        else if (roll <= _chanceSpawn)
        {
            _chanceSpawn /= DividerHalf;
            OnClicked?.Invoke(this);
        }

        _explosion.Explode();
        OnBeforeDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}
