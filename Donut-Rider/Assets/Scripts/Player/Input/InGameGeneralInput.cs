public class InGameGeneralInput : IInput
{
    private PlayerInput input;
    private GameController gameController;

    public InGameGeneralInput(PlayerInput newInput, GameController gameController)
    {
        input = newInput;
        input.InGameGeneral.Pause.performed += ctx => gameController.SwitchPause();
    }
    public void Enable()
    {
        input.InGameGeneral.Enable();
    }

    public void Disable()
    {
        input.InGameGeneral.Disable();
    }
}
