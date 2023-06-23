public class InGameGeneralInput : IInput
{
    private PlayerInput input;
    private GameController currentGameController;

    public InGameGeneralInput(PlayerInput newInput, GameController gameController)
    {
        input = newInput;
        currentGameController = gameController;
    }
    public void Enable()
    {
        input.InGameGeneral.Enable();
        input.InGameGeneral.Pause.performed += ctx => currentGameController.SwitchPause();
    }

    public void Disable()
    {
        input.InGameGeneral.Disable();
        input.InGameGeneral.Pause.performed -= ctx => currentGameController.SwitchPause();
    }
}
