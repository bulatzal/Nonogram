using UnityEngine;
using UnityEngine.UI;

public class NonogramController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private RectTransform gridRectTransform;
    [SerializeField] private TipsController infoTipsController;

    private Picture _picture;

    private void Start()
    {
        var picture = new Picture(new bool[,]
        {
            { true, false, true, false, true },
            { true, true, true, true, true },
            { false, true, true, true, false },
            { false, true, false, true, false },
            { false, true, true, true, false }
        });
        _picture = picture;

        CreateField(_picture);
        infoTipsController.CreateTips(_picture);
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
            }
        }
    }

    public Picture GetPicture()
    {
        return _picture;
    }
}
