using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellSelection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Direction direction;
    private Cell selectedCell;
    private LinkedList<Cell> selectedCells = new LinkedList<Cell>();

    private void AddCellInGroup(Cell selectedCell)
    {
        if (selectedCell != null && !selectedCell.CheckIsClicked())
        {
            selectedCell.ChangeColor(Color.cyan);
            selectedCells.AddLast(selectedCell);
        }
    }

    private void RemoveCellFromGroup(Cell selectedCell)
    {
        if (selectedCell != null && selectedCells.Contains(selectedCell))
        {
            selectedCell.ChangeColor(Color.white);
            selectedCells.Remove(selectedCell);
        }
    }

    public Cell GetNext(Cell selectedCell)
    {
        if (selectedCell != null)
        {
            int index = -1;
            foreach (Cell cell in selectedCells)
            {
                index++;
                if (cell == selectedCell)
                {
                    if (index > -1)
                    {
                        if (cell != selectedCells.Last.Value)
                        {
                            return selectedCells.ElementAt(index + 1);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        return null;
    }

    public bool CheckIsNearby(Cell selectedCell)
    {
        // Если ячейка была добавлена в группу, то игнорируем
        if (selectedCells.Contains(selectedCell))
        {
            return false;
        }

        // Если это первая ячейка, то добавляем
        if (selectedCells.Count == 0)
        {
            return true;
        }
        // Если это вторая ячейка, то проверяем, чтобы она была на расстояние 1 от последней и задаем направление
        else if (selectedCells.Count == 1)
        {
            var lastCell = selectedCells.Last.Value;
            if (lastCell.row == selectedCell.row)
            {
                var difference = lastCell.column - selectedCell.column;
                if (difference == 1)
                {
                    direction = Direction.Left;
                    return true;
                }
                else if (difference == -1)
                {
                    direction = Direction.Right;
                    return true;
                }
            }
            else if (lastCell.column == selectedCell.column)
            {
                var difference = lastCell.row - selectedCell.row;
                if (difference == 1)
                {
                    direction = Direction.Up;
                    return true;
                }
                else if (difference == -1)
                {
                    direction = Direction.Down;
                    return true;
                }
            }
        }
        // Иначе проверяем направление и, чтобы она была на расстояние 1 от последней 
        else
        {
            var lastCell = selectedCells.Last.Value;
            if (lastCell.row == selectedCell.row)
            {
                var difference = lastCell.column - selectedCell.column;
                return (difference == 1 && direction == Direction.Left) || (difference == -1 && direction == Direction.Right);
            }
            else if (lastCell.column == selectedCell.column)
            {
                var difference = lastCell.row - selectedCell.row;
                return (difference == 1 && direction == Direction.Up) || (difference == -1 && direction == Direction.Down);
            }
        }

        return false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selectedCell = GetComponent<Cell>();
        AddCellInGroup(selectedCell);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var result = eventData.pointerCurrentRaycast;

        if (result.gameObject == null || result.gameObject != null && result.gameObject.GetComponent<Cell>() == null)
        {
            foreach (var cell in selectedCells)
            {
                cell.ChangeColor(Color.white);
            }
            selectedCells.Clear();
            return;
        }

        foreach (var cell in selectedCells)
        {
            cell.OpenCell();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var result = eventData.pointerCurrentRaycast;

        if (result.gameObject != null)
        {
            selectedCell = result.gameObject.GetComponent<Cell>();

            if (selectedCell != null && !selectedCell.CheckIsClicked())
            {
                if (GetNext(selectedCell) == selectedCells.Last.Value)
                {
                    RemoveCellFromGroup(selectedCells.Last.Value);
                }
                else
                {
                    if (CheckIsNearby(selectedCell))
                    {
                        AddCellInGroup(selectedCell);
                    }
                }
            }
        }
    }
}

public enum Direction
{
    Left, Right, Up, Down
}