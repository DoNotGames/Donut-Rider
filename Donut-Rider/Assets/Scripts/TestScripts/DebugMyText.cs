using UnityEngine;

public class DebugMyText : MonoBehaviour
{
    [SerializeField] private string text;
    public void DebugText()
    {
        Debug.Log(text);
    }
}
