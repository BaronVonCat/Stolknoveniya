using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Interacted;

    [field: SerializeField] public float ChanceSpawn { get; private set; }

    public Collider Collider { get; private set; }

    private bool _isInitialize = false;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
    }

    public void Intract()
    {
        Interacted?.Invoke(this);
    }

    public void Initialize(float chanceSpawn)
    {
        if (_isInitialize == false)
        {
            ChanceSpawn = chanceSpawn;
            _isInitialize = true;
        }
    }
}
