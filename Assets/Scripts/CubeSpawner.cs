using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{ 
    [SerializeField] private List<Cube> _cubes = new List<Cube>();
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] private float _scaleMultiplier = 1f;

    private void OnEnable()
    {
        CleanupDestroyedCubes();
        SubscribeCubes();
    }

    private void OnDisable()
    {
        UnsubscribeCubes();
    }

    public List<Cube> Spawn(Cube cube)
    {
        List<Cube> cubes = new List<Cube>();
        int spawnCount = UnityEngine.Random.Range(_spawnCountMin, _spawnCountMax);

        for (int i = 0; i < spawnCount; i++)
        {
            cubes.Add(CreateCoub(cube));
        }

        return cubes;
    }

    private Cube CreateCoub(Cube cube)
    {
        const float DividerHalf = 2;

        Cube newCube = Instantiate(cube);

        newCube.Initialize(cube.ChanceSpawn/DividerHalf);
        newCube.transform.localScale *= _scaleMultiplier;
        newCube.name = cube.name;
        newCube.Interacted += OnInteracted;
        _cubes.Add(newCube);

        return newCube;
    }

    private void CleanupDestroyedCubes()
    {
        _cubes.RemoveAll(c => c == null);
    }

    private void SubscribeCubes()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Interacted += OnInteracted;
        }
    }

    private void UnsubscribeCubes()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Interacted -= OnInteracted;
        }
    }

    private void OnInteracted(Cube cube)
    {
        cube.Interacted -= OnInteracted;
        _cubes.Remove(cube);
        Destroy(cube.gameObject);
    }
}
