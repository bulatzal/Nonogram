using TMPro;
using UnityEngine;

public class TipsController : MonoBehaviour
{
    [SerializeField] private RectTransform rows;
    [SerializeField] private RectTransform columns;
    [SerializeField] private GameObject rowInfoPrefab;
    [SerializeField] private GameObject columnInfoPrefab;
    [SerializeField] private GameObject infoNumberPrefab;

    /// <summary>
    /// Создать числовые подсказки
    /// </summary>
    public void CreateTips(Picture picture)
    {
        var size = picture.GetPictureSize();
        var tipLineSize = columns.sizeDelta.x / size;

        // Верхние подсказки
        for (int columnNum = 0; columnNum < size; columnNum++)
        {
            var column = Instantiate(columnInfoPrefab, columns);
            var columnTransform = column.GetComponent<RectTransform>();
            columnTransform.sizeDelta = new Vector2(tipLineSize, columns.sizeDelta.y - 0.01f);

            var tips = picture.GetLineNumbers(columnNum, false);
            var tipSize = columnTransform.sizeDelta.y / tips.Count;
            foreach (var tip in tips)
            {
                var columnNumber = Instantiate(infoNumberPrefab, column.transform).GetComponent<TextMeshProUGUI>();
                columnNumber.text = tip.ToString();
                columnNumber.alignment = TextAlignmentOptions.Bottom;
                columnNumber.GetComponent<RectTransform>().sizeDelta = new Vector2(tipLineSize, tipSize);
            }
        }

        // Боковые подсказки
        for (int rowNum = 0; rowNum < size; rowNum++)
        {
            var row = Instantiate(rowInfoPrefab, rows);
            var rowTransform = row.GetComponent<RectTransform>();
            rowTransform.sizeDelta = new Vector2(rows.sizeDelta.x - 0.01f, tipLineSize);

            var tips = picture.GetLineNumbers(rowNum, true);
            var tipSize = rowTransform.sizeDelta.x / tips.Count;
            foreach (var tip in tips)
            {
                var rowNumber = Instantiate(infoNumberPrefab, row.transform).GetComponent<TextMeshProUGUI>();
                rowNumber.text = tip.ToString();
                rowNumber.GetComponent<RectTransform>().sizeDelta = new Vector2(tipSize, tipLineSize);
            }
        }
    }
}
