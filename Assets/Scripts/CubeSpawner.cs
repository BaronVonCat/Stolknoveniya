using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CubeSpawner : MonoBehaviour
{ 
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] float _scaleMultiplier = 1f;

    private void OnEnable()
    {
        SubscribeExistingCubes();
    }

    private void OnDisable()
    {
        UnsubscribeExistingCubes();
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
    }
   
    private void SubscribeExistingCubes()
    {
        List<Cube> cubes = FindObjectsByType<Cube>(FindObjectsSortMode.None).ToList();

        foreach (Cube cube in cubes)
        {
            cube.OnClicked += Spawn;
        }
    }

    private void UnsubscribeExistingCubes()
    {
        List<Cube> cubes = FindObjectsByType<Cube>(FindObjectsSortMode.None).ToList();

        foreach (Cube cube in cubes)
        {
            cube.OnClicked -= Spawn;
        }
    }
}
