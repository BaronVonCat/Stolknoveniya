using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private RaycasterCube _raycasterCube;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Explosion _explosion;

    private void OnEnable()
    {
        _raycasterCube.ClickedCube += OnClickedCube;
    }

    private void OnDisable()
    {
        _raycasterCube.ClickedCube -= OnClickedCube;
    }

    private void OnClickedCube(Cube cube)
    {
        if (CanSpawn(cube))
        {
            List<Cube> cubes = _spawner.Spawn(cube);
            _explosion.Explode(cube.transform, cubes.Select(c => c.Collider));
        }

        cube.Intract();
    }

    private bool CanSpawn(Cube cube)
    {
        const float ChanceSpawnMax = 100f;

        float chanceToDivide = Random.Range(0, ChanceSpawnMax);

        return chanceToDivide <= cube.ChanceSpawn;
    }
}
