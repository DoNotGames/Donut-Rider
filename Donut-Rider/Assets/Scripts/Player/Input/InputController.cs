using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private DebugMyText debugMyText;
    [SerializeField] private GameController gameController;

    private PlayerInput playerInput;
    private GlobalInput globalInput;
    private TestInput testInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        testInput = new TestInput(playerInput, debugMyText);
        globalInput = new GlobalInput(playerInput, gameController);

        globalInput.Enable();
    }

    public TestInput GetTestInput()
    {
        return testInput;
    }
}
