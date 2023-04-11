using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleFilter : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    GameObject gameObjectToUse;

    public void Start()
    {
        gameObjectToUse = GameObject.Find("Donut(Clone)").transform.GetChild(1).gameObject;//XD
    }

    void Update()
    {
        Vector3 viewportLocation = Camera.main.WorldToViewportPoint(gameObjectToUse.transform.position);
        rectTransform.offsetMin = new Vector2(viewportLocation.x * Screen.width, rectTransform.offsetMin.y);
    }
}
