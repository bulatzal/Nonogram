using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScaler;

    private Vector2 portraitReferenceResolution = new Vector2(1080, 1920);
    private Vector2 landscapeReferenceResolution = new Vector2(1920, 1080);

    private void Update()
    {
        if (Screen.width > Screen.height)
        {
            canvasScaler.referenceResolution = landscapeReferenceResolution;
            canvasScaler.matchWidthOrHeight = 1;
        }
        else
        {
            canvasScaler.referenceResolution = portraitReferenceResolution;
            canvasScaler.matchWidthOrHeight = 0;
        }
    }
}
