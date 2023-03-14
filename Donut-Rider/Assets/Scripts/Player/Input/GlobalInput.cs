public class GlobalInput
{
    private PlayerInput input;

    public GlobalInput(PlayerInput newInput, GameController newGameController)
    {
        input = newInput;
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
