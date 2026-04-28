using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        Material newMaterial = new Material(_renderer.material);

        _renderer.material = newMaterial;
        newMaterial.color = Random.ColorHSV();
    }
}
