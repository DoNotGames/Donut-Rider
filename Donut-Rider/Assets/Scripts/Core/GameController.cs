using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject debugTestUI;
    [SerializeField] private TMP_Text TestInputStatusText;

    private InputController inputController;
    private TestInput testInput;
    private bool isTestInputOn;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        testInput = inputController.GetTestInput();
        isTestInputOn = false;
        TestInputStatusText.text = "TestInputs is OFF";
    }

    public void SwitchTestInput()
    {
        isTestInputOn = !isTestInputOn;

        if (isTestInputOn)
        {
            testInput.Enable();
            debugTestUI.SetActive(true);
            TestInputStatusText.text = "TestInputs is ON";
            return;
        }

        testInput.Disable();
        debugTestUI.SetActive(false);
        TestInputStatusText.text = "TestInputs is OFF";
    }
}
