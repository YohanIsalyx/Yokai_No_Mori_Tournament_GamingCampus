using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;
using YokaiNoMori.Interface;

public class Piece : IPawn
{

	public IBoardCase CurrentBoardCase
	{
		get { return m_currentBoardCase; }
		private set { m_currentBoardCase = value; }
	}


	public ECampType CurrentPlayerCamp
	{
		get { return m_currentPlayerCamp; }
		private set { m_currentPlayerCamp = value; }
	}


	public ICompetitor CurrentPlayerProperty
	{
		get { return m_currentPlayerOwner; }
		private set { m_currentPlayerOwner = value; }
	}


	public CommonPieceData Data
	{
		get { return data; }
		private set { data = value; }
	}



	public Piece(IBoardCase newCase, ECampType currentCamp, CommonPieceData data)
	{
        CurrentBoardCase = newCase;
		Data = data;
		ChangeCamp(currentCamp);
    }

	public void InitPiece()
	{
		CurrentPlayerProperty = CurrentPlayerCamp == ECampType.PLAYER_ONE ? GameManager.Instance.CompetitorsManager.PlayerOne : GameManager.Instance.CompetitorsManager.PlayerTwo;
	}


	public void ChangeCamp(ECampType newCamp)
	{
		CurrentPlayerCamp = newCamp;
	}

	public void GetCapturedBy(ICompetitor competitor)
	{
		CurrentBoardCase = null;
		ChangeCamp(competitor.GetCamp());
    }

    public List<Vector2Int> GetDirections()
    {
		List<Vector2Int> directions = new List<Vector2Int>();


		#region F/W MID
		if (Data.MovementType.HasFlag(EMovementType.FORWARD_MID))
            directions.Add(new Vector2Int(0, 1));


		if (Data.MovementType.HasFlag(EMovementType.BACK_MID))
            directions.Add(new Vector2Int(0, -1));


		#endregion


		#region RIGHT
		if (Data.MovementType.HasFlag(EMovementType.FORWARD_RIGHT))
            directions.Add(new Vector2Int(1, 1));


		if (Data.MovementType.HasFlag(EMovementType.BACK_RIGHT))
			directions.Add(new Vector2Int(1, -1));


        if (Data.MovementType.HasFlag(EMovementType.MID_RIGHT))
            directions.Add(new Vector2Int(1, 0));

        #endregion


        #region LEFT

        if (Data.MovementType.HasFlag(EMovementType.FORWARD_LEFT))
			directions.Add(new Vector2Int(-1, 1));


		if (Data.MovementType.HasFlag(EMovementType.BACK_LEFT))
            directions.Add(new Vector2Int(-1, -1));


        if (Data.MovementType.HasFlag(EMovementType.MID_LEFT))
            directions.Add(new Vector2Int(-1, 0));

		#endregion

		return directions;
    }

    public ICompetitor GetCurrentOwner()
    {
		return m_currentPlayerOwner;
    }

    public IBoardCase GetCurrentBoardCase()
    {
		return m_currentBoardCase;
    }

    private ECampType m_currentPlayerCamp;
    private IBoardCase m_currentBoardCase;
    private ICompetitor m_currentPlayerOwner;

    private CommonPieceData data;
}
