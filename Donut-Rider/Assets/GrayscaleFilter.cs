using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleFilter : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    private GameObject _gameObjectToUse;

    public void Init(GameObject gameObjectToUse)
    {
        _gameObjectToUse = gameObjectToUse;

        //rectTransform.

        enabled = true;
    }

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        Vector3 viewportLocation = Camera.main.WorldToViewportPoint(_gameObjectToUse.transform.position);
        rectTransform.offsetMin = new Vector2(viewportLocation.x * Screen.width, rectTransform.offsetMin.y);
    }
}
