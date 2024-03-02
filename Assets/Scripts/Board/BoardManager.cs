using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YokaiNoMori.Interface;


public class BoardManager
{
	public readonly int BOARD_ROWS;
    public readonly int BOARD_COLUMNS;


	public BoardManager(BoardData boardData)
	{
		BOARD_ROWS = boardData.Row;
		BOARD_COLUMNS = boardData.Col;
	}


	public List<IBoardCase> BoardCases
	{
		get { return m_boardCases; }
		private set { m_boardCases = value; }
	}

	public void InitBoard()
    {
		BoardCases = new List<IBoardCase>();

		for(int row = 0; row < BOARD_ROWS; row++)
		{
			for(int column = 0; column < BOARD_COLUMNS; column++)
			{
				if(row == 0 || row == 4)
				{
                    BoardCases.Add(new SpecialBoardCase(row, column));
                }
                else
                {
					BoardCases.Add(new BoardCase(row, column));
                }
            }
		}

		PlacePieceOnBoard();
    }

	private void PlacePieceOnBoard()
	{
		BoardData boardData = Resources.Load<BoardData>("Datas/Board/4x3");

		foreach (SBoardCase caseData in boardData.BoardCases)
		{
			foreach (BoardCase bCase in BoardCases)
			{
				if(caseData.Position == bCase.Position)
				{
					Piece piece = new Piece(bCase, caseData.Camp, caseData.PieceData);
					bCase.SetCurrentPiece(piece);
				}
			}
		}
	}

	public IBoardCase GetBoardCase(Vector2 position)
	{
        return BoardCases.FirstOrDefault(x => x.GetPosition() == position);
    }




    private List<IBoardCase> m_boardCases;
}
