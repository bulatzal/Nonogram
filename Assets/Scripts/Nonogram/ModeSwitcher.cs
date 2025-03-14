using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    [Header("Toggles")]
    [SerializeField] private Toggle excludeToggle;
    [SerializeField] private Toggle selectToggle;

    public static bool IsExcludeModeActive { get; private set; }

    private void Start()
    {
        excludeToggle.onValueChanged.AddListener(OnExcludeModeToggled);
        selectToggle.onValueChanged.AddListener(OnSelectModeToggled);

        IsExcludeModeActive = excludeToggle.isOn;
    }

    private void OnExcludeModeToggled(bool isOn)
    {
        if (isOn)
        {
            IsExcludeModeActive = true;
        }
    }

    private void OnSelectModeToggled(bool isOn)
    {
        if (isOn)
        {
            IsExcludeModeActive = false;
        }
    }
}
