using System;

public interface IInputService
{
    public event Action<float> OnInputX;
}