using UnityEngine;

public static class InputManager
{
    private static Controls _ctrls;

    public static void Init(BallController b)
    {
        _ctrls = new();

        _ctrls.InGame.Enable();

        _ctrls.InGame.ToggleDirection.performed += watchClick =>
        {
            b.SwapAxis();
        };
    }

    public static void EnableInGame()
    {
        _ctrls.InGame.Enable();
    }
}
