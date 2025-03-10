using System.Collections.Generic;

public class Picture
{
    private bool[,] picture;

    public Picture(bool[,] picture)
    {
        this.picture = picture;
    }

    public bool GetPictureFrame(int row, int column)
    {
        return picture[row, column];
    }

    public int GetPictureSize()
    {
        return picture.GetLength(0);
    }

    public List<int> GetLineNumbers(int line, bool isHorizontal)
    {
        List<int> lineResult = new List<int>();
        int count = 0;

        for (int i = 0; i < GetPictureSize(); i++)
        {
            if (picture[isHorizontal ? line : i, isHorizontal ? i : line])
            {
                count++;
            }
            else if (i > 0 && picture[isHorizontal ? line : i - 1, isHorizontal ? i - 1 : line])
            {
                lineResult.Add(count);
                count = 0;
            }
        }

        if (count > 0)
        {
            lineResult.Add(count);
        }

        return lineResult;
    }
}
