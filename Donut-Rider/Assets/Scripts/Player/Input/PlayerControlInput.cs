public class PlayerControlInput
{
    private PlayerInput input;

    public PlayerControlInput(PlayerInput newInput, DonutController donutController)
    {
        input = newInput;

        input.Donut.Thrust.performed += ctx => donutController.Thrust();
        input.Donut.Breake.performed += ctx => donutController.Brake(true);
        input.Donut.Breake.canceled += ctx => donutController.Brake(false);
    }

    public void Enable()
    {
        input.Donut.Enable();
    }

    public void Disable()
    {
        input.Donut.Disable();
    }
}
