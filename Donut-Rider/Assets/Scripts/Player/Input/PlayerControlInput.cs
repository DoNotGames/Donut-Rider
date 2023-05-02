public class PlayerControlInput : IInput
{
    private PlayerInput input;

    public PlayerControlInput(PlayerInput newInput, DonutMenager donutMenager)
    {
        input = newInput;

        input.Donut.Thrust.performed += ctx => donutMenager.Thrust();
        input.Donut.Thrust.canceled += ctx => donutMenager.EndThrust();
        input.Donut.Breake.performed += ctx => donutMenager.Brake();
        input.Donut.Breake.canceled += ctx => donutMenager.EndBrake();
        input.Donut.Jump.performed += ctx => donutMenager.Jump();
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
