using UnityEngine;

public class CanvasUtility : MonoBehaviour
{
    public CanvasGroup canvas;

    public void TurnOn()
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

    public void TurnOff()
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
}