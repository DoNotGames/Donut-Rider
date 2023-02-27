public class GlobalInput
{
    private PlayerInput input;

    public GlobalInput(PlayerInput newInput, GameController newGameController)
    {
        input = newInput;

        input.Global.SwitchTestInputs.performed += ctx => newGameController.SwitchTestInput();
    }

    public void Enable()
    {
        input.Global.Enable();
    }

    public void Disable()
    {
        input.Global.Disable();
    }
}
