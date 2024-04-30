using System;
using UnityEngine;

public class MobileInputService : MonoBehaviour, IInputService
{
    public event Action<float> OnInputX;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                OnInputX?.Invoke(1);
            }
            else
            {
                OnInputX?.Invoke(-1);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnInputX?.Invoke(0);
        }
    }
}