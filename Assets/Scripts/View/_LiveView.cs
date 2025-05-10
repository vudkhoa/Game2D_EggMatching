using TMPro;
using UnityEngine;

public class _LiveView : MonoBehaviour
{
    private TextMeshProUGUI liveText;

    private void Awake()
    {
        liveText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(int live)
    {
        if (liveText == null) return;
        liveText.text = "Live: " + live.ToString();
    }
}
