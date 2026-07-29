using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Clicked?.Invoke();
        }
    }
}
