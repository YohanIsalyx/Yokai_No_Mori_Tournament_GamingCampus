using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Data", menuName = "Board/Board Data", order = 0)]
public class BoardData : ScriptableObject
{
    public int Row;
    public int Col;
    public List<SBoardCase> BoardCases;
}
