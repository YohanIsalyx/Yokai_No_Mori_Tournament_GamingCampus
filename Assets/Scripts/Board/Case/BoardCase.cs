using UnityEngine;
using YokaiNoMori.Interface;

public class BoardCase : IBoardCase
{
	public Vector2 Position
	{
		get { return m_position; }
		private set { m_position = value; }
	}

	public IPawn CurrentPiece
	{
		get { return m_currentPiece; }
		private set { m_currentPiece = value; }
	}


	public BoardCase(int row, int col)
	{
        Position = new Vector2(row, col);
	}

	public void SetCurrentPiece(IPawn piece)
	{
		if(CurrentPiece is not null)
		{
			GameManager.Instance.FightManager.DoFight(piece, CurrentPiece);
		}
        CurrentPiece = piece;
	}

    public Vector2Int GetPosition()
    {
        throw new System.NotImplementedException();
    }

    public IPawn GetPawnOnIt()
    {
        throw new System.NotImplementedException();
    }

    private Vector2 m_position;
    private IPawn m_currentPiece;
}
