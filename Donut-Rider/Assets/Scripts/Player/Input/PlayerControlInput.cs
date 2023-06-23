public class PlayerControlInput : IInput
{
    private PlayerInput input;
    private DonutMenager currentDonutManager;

    public PlayerControlInput(PlayerInput newInput, DonutMenager donutMenager)
    {
        input = newInput;
        currentDonutManager = donutMenager;
    }

    public void Enable()
    {
        input.Donut.Enable();

        input.Donut.Thrust.performed += ctx => currentDonutManager.Thrust();
        input.Donut.Thrust.canceled += ctx => currentDonutManager.EndThrust();
        input.Donut.Breake.performed += ctx => currentDonutManager.Brake();
        input.Donut.Breake.canceled += ctx => currentDonutManager.EndBrake();
        input.Donut.Jump.performed += ctx => currentDonutManager.Jump();
    }

    public void Disable()
    {
        input.Donut.Disable();

        input.Donut.Thrust.performed -= ctx => currentDonutManager.Thrust();
        input.Donut.Thrust.canceled -= ctx => currentDonutManager.EndThrust();
        input.Donut.Breake.performed -= ctx => currentDonutManager.Brake();
        input.Donut.Breake.canceled -= ctx => currentDonutManager.EndBrake();
        input.Donut.Jump.performed -= ctx => currentDonutManager.Jump();
    }
}
