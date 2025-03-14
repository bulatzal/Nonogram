using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;
    [SerializeField] private Button levelButtonPrefab;

    private int currentPage = 0;
    private const int levelsPerPage = 8;

    private void Start()
    {
        UpdateLevelPage();
    }

    private void UpdateLevelPage()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int startIndex = currentPage * levelsPerPage;
        int endIndex = Mathf.Min(startIndex + levelsPerPage, levels.Length);

        for (int i = startIndex; i < endIndex; i++)
        {
            var levelButton = Instantiate(levelButtonPrefab, transform);
            var levelIndex = i;
            levelButton.GetComponentInChildren<TextMeshProUGUI>().text = (levelIndex + 1).ToString();
            levelButton.onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    private void LoadLevel(int levelIndex)
    {
        GameManager.Instance.currentLevelData = levels[levelIndex];
        SceneManager.LoadScene("Nonogram");
    }
}
