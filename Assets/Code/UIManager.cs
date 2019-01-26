using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text InteractLabel;
    public Text ObjectLabel;

    private void Start()
    {
        InteractLabel.text = "";
        ObjectLabel.text = "";
    }

    public void SetInteractionText(string text)
    {
        InteractLabel.text = text;
    }

    public void SetObjectName(string text)
    {
        ObjectLabel.text = text;
    }
}
