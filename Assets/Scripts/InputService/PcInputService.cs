using System;
using UnityEngine;

public class PcInputService : MonoBehaviour, IInputService
{
    public event Action<float> OnInputX;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        OnInputX?.Invoke(Input.GetAxis("Horizontal"));
    }
}