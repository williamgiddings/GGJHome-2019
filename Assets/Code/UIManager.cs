using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text InteractLabel;
    public Text ObjectLabel;
    public Text ObjectiveLabel;

    private void Start()
    {
        InteractLabel.text = "";
        ObjectLabel.text = "";
        ObjectiveLabel.text = "";
    }

    public void SetInteractionText(string text)
    {
        InteractLabel.text = text;
    }

    public void SetObjectName(string text)
    {
        ObjectLabel.text = text;
    }

    public void SetObjectiveText(string text)
    {
        ObjectiveLabel.text = text;
    }
}
