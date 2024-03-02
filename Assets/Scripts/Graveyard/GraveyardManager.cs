using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;
using YokaiNoMori.Interface;



/// <summary>
/// Cette classe contient les cimetières des joueurs. Elle possède aussi les actions d'envoi et de parachutage des pièces
/// </summary>
public class GraveyardManager
{
	public Graveyard PlayerOneGraveyard
	{
		get { return m_playerOneGraveyard; }
		private set { m_playerOneGraveyard = value; }
	}


	public Graveyard PlayerTwoGraveyard
	{
		get { return m_playerTwoGraveyard; }
		private set { m_playerTwoGraveyard = value; }
	}


	public void InitGraveyard()
	{
		PlayerOneGraveyard = new Graveyard();
		PlayerTwoGraveyard = new Graveyard();

		PlayerOneGraveyard.Init();
		PlayerTwoGraveyard.Init();
	}



	public void SendToGraveyard(IPawn piece, ICompetitor player)
	{
        if (player.GetCamp() == ECampType.PLAYER_ONE)
			PlayerOneGraveyard.AddToGraveyard(piece);
		else if(player.GetCamp() == ECampType.PLAYER_TWO)
			PlayerTwoGraveyard.AddToGraveyard(piece);
		else
			throw new System.Exception("ERROR : Piece is send in NONE Camp");

        (piece as Piece).GetCapturedBy(player);
    }

	public void RemovePieceToGraveyard(IPawn piece, ECampType playerCamp)
	{
        if (playerCamp == ECampType.PLAYER_ONE)
            PlayerOneGraveyard.AddToGraveyard(piece);
        else if (playerCamp == ECampType.PLAYER_TWO)
            PlayerTwoGraveyard.AddToGraveyard(piece);
        else
            throw new System.Exception("ERROR : Piece is send in NONE Camp");
    }



    private Graveyard m_playerOneGraveyard;
    private Graveyard m_playerTwoGraveyard;
}
