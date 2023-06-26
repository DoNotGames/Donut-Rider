using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private DebugMyText debugMyText;
    [SerializeField] private GameController gameController;

    private DonutMenager donutController;

    private PlayerInput playerInput;
    private InGameGeneralInput inGameGeneralInput;
    private PlayerControlInput playerControlInput;

    private Dictionary<string, IInput> inputs;

    private void Start()
    {
        inputs = new Dictionary<string, IInput>();

        playerInput = new PlayerInput();
        inGameGeneralInput = new InGameGeneralInput(playerInput, gameController);
        inputs.Add("InGameGeneralInput", inGameGeneralInput);

        donutController = GameObject.FindGameObjectWithTag("Player").GetComponent<DonutMenager>();
        playerControlInput = new PlayerControlInput(playerInput, donutController);
        inputs.Add("PlayerControlInput", playerControlInput);

        playerControlInput.Enable();
        inGameGeneralInput.Enable();
    }

    public void DisableInput(string inputName)
    {
        inputs[inputName].Disable();
    }

    public void EnableInput(string inputName)
    {
        inputs[inputName].Enable();
    }

    private void OnDisable()
    {
        playerControlInput.Disable();
        inGameGeneralInput.Disable();
    }
}
