using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public event Action OnClickedIncorrectly;
    public int row;
    public int column;
    public bool isFilled;

    [SerializeField] private Image image;
    private bool isClicked;
    private Color blueColor = new Color(51f / 255f, 71f / 255f, 96f / 255f);
    private Color redColor = new Color(255f / 255f, 43f / 255f, 55f / 255f);

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
                ChangeColor(blueColor);
            }
            else
            {
                ChangeColor(redColor);
                OnClickedIncorrectly?.Invoke();
            }

            isClicked = true;
        }
    }

    public void ChangeColor(Color color)
    {
        image.color = color;
    }
}
