using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PixelCameraController : MonoBehaviour
{
    [SerializeField] private PixelPerfectCamera pixelCamera;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        if (Application.isMobilePlatform)
        {
            pixelCamera.refResolutionX = 180;
            pixelCamera.refResolutionY = 180;
        }
        else
        {
            pixelCamera.refResolutionX = 640;
            pixelCamera.refResolutionY = 360;
        }
    }
}
