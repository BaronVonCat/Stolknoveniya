using UnityEngine;
using System;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private const float DividerTwo = 2;

    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private bool _isGuaranteedSpawn = false;
    [SerializeField] private float _chanceSpawn = 1f;

    public UnityEvent OnBeforeDestroy;
    public event Action<Cube> OnClicked;

    private void OnMouseDown()
    {
        float roll = UnityEngine.Random.Range(0f, 1f);

        if (_isGuaranteedSpawn == true)
        {
            OnClicked?.Invoke(this);
        }
        else if (roll <= _chanceSpawn)
        {
            _chanceSpawn /= DividerTwo;
            OnClicked?.Invoke(this);
        }

        OnBeforeDestroy?.Invoke();
        Destroy(gameObject);
    } 
}
