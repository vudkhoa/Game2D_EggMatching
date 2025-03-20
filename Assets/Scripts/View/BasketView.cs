using UnityEngine;

public class BasketView : MonoBehaviour
{
    public RectTransform rect;

    private void Start()
    {
        this.rect = GetComponent<RectTransform>();
    }
}
