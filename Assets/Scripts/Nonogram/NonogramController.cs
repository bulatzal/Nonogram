using UnityEngine;
using UnityEngine.UI;

public class NonogramController : MonoBehaviour
{
    [Header("Nonogram Info")]
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private RectTransform gridRectTransform;
    private Picture _picture;
    private int clickedCells;

    [Header("Controllers")]
    [SerializeField] private TipsController infoTipsController;
    [SerializeField] private LivesController livesController;

    private void Start()
    {
        _picture = LoadLevelData();
        clickedCells = 0;

        CreateField(_picture);
        infoTipsController.CreateTips(_picture);
    }

    private Picture LoadLevelData()
    {
        var levelData = GameManager.Instance.currentLevelData;
        bool[,] field = new bool[levelData.gridSize, levelData.gridSize];

        for (int i = 0; i < levelData.gridSize; i++)
        {
            for (int j = 0; j < levelData.gridSize; j++)
            {
                field[i, j] = levelData.gridData[i * levelData.gridSize + j];
            }
        }

        return new Picture(field);
    }

    private void CreateField(Picture picture)
    {
        var size = picture.GetPictureSize();
        grid.cellSize = gridRectTransform.rect.size / size;
        grid.constraintCount = size;

        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                var cell = Instantiate(cellPrefab, grid.transform).GetComponent<Cell>();

                cell.isFilled = picture.GetPictureFrame(row, column);
                cell.row = row;
                cell.column = column;
                cell.OnClicked += CheckProgress;
                cell.OnClickedIncorrectly += livesController.TakeDamage;
            }
        }
    }

    public Picture GetPicture()
    {
        return _picture;
    }

    private void CheckProgress()
    {
        clickedCells++;

        if (clickedCells == Mathf.Pow(_picture.GetPictureSize(), 2))
        {
            Debug.Log("Уровень пройден");
        }
    }
}
