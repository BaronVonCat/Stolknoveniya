using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material newMaterial = new Material(renderer.material);

        renderer.material = newMaterial;
        newMaterial.color = Random.ColorHSV();
    }
}
