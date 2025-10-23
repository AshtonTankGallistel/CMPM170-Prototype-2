using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlayPanel; // Assign this in the inspector

    public void ShowPanel()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HidePanel()
    {
        howToPlayPanel.SetActive(false);
    }
}
