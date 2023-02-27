public class TestInput
{
    private PlayerInput input;
    private DebugMyText debugMyText;

    public TestInput(PlayerInput newInput, DebugMyText newDebugMyText)
    {
        input = newInput;
        debugMyText = newDebugMyText;

        input.Tests.TestMe.performed += ctx => debugMyText.DebugText();
    }

    public void Enable()
    {
        input.Tests.Enable();
    }

    public void Disable()
    {
        input.Tests.Disable();
    }
}
