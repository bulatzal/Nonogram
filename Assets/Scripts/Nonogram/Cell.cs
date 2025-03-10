using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image image;
    public bool isFilled;
    private bool isClicked;

    public int row;
    public int column;

    public bool CheckIsFilled()
    {
        return isFilled;
    }
    public bool CheckIsClicked()
    {
        return isClicked;
    }

    public void OpenCell()
    {
        if (!isClicked)
        {
            if (isFilled)
            {
                ChangeColor(Color.blue);
            }
            else
            {
                ChangeColor(Color.red);
            }

            isClicked = true;
        }
    }

    public void ChangeColor(Color color)
    {
        image.color = color;
    }
}
