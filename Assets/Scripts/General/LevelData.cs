using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Levels/LevelData")]
public class LevelData : ScriptableObject
{
    public int levelIndex;
    public int gridSize;
    public bool[] gridData;
}
