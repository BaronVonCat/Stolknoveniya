using System;
using UnityEngine;

public class RaycasterCube : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> ClickedCube;

    private void OnEnable()
    {
        _inputReader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out Cube cube))
            {
                ClickedCube?.Invoke(cube);
            }
        }
    }
}
