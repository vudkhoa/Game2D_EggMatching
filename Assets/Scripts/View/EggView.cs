using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class EggView : MonoBehaviour
{
    public float speedFall;

    private RectTransform rect;

    public void SetSpeedFall(float speedFall)
    {
        this.speedFall = speedFall;
    }

    private void Start()
    {
        this.rect = GetComponent<RectTransform>();
    }

    public void MoveEgg(int row, float xPos, float yPos, float distance)
    {
        if (rect == null) return;
        if (row != 1)
        {
            rect.anchoredPosition = new Vector2(xPos, yPos - distance);
        }
        else if (yPos - distance != 0)
        {
            rect.anchoredPosition = new Vector2(xPos, -545);
            //Destroy(gameObject);
        }
    }
}
