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

    public void Spawn(Cube cube)
    {
        int spawnCount = UnityEngine.Random.Range(_spawnCountMin, _spawnCountMax);

        for (int i = 0; i < spawnCount; i++)
        {
            CreateCoub(cube);
        }
    }

    private void CreateCoub(Cube cube)
    {
        Cube newCube = Instantiate(cube);

        newCube.transform.localScale *= _scaleMultiplier;
        newCube.name = cube.name;
        newCube.OnClicked += Spawn;
        newCube.OnBeforeDestroy += RemoveDestroyedCube;
        _cubes.Add(newCube);
    }

    private void CleanupDestroyedCubes()
    {
        _cubes.RemoveAll(c => c == null);
    }

    private void RemoveDestroyedCube(Cube cube)
    {
        _cubes.Remove(cube);
    }

    private void SubscribeCubes()
    {
        foreach (Cube cube in _cubes)
        {
            cube.OnClicked += Spawn;
            cube.OnBeforeDestroy += RemoveDestroyedCube;
        }
    }

    private void UnsubscribeCubes()
    {
        foreach (Cube cube in _cubes)
        {
            cube.OnClicked -= Spawn;
            cube.OnBeforeDestroy -= RemoveDestroyedCube;
        }
    }
}
