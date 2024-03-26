using UnityEngine;
using YokaiNoMori.Enumeration;
using YokaiNoMori.Interface;

namespace YokaiNoMori.General
{

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
            (piece as Pawn).GetCapturedBy(player);

            if (player.GetCamp() == ECampType.PLAYER_ONE)
				PlayerOneGraveyard.AddToGraveyard(piece);
			else if (player.GetCamp() == ECampType.PLAYER_TWO)
				PlayerTwoGraveyard.AddToGraveyard(piece);
			else
				throw new System.Exception("ERROR : Piece is send in NONE Camp");

        }

		public void RemovePieceToGraveyard(IPawn piece)
		{
			if (piece.GetCurrentOwner().GetCamp() == ECampType.PLAYER_ONE)
				PlayerOneGraveyard.RemoveToGraveyard(piece);
			else if (piece.GetCurrentOwner().GetCamp() == ECampType.PLAYER_TWO)
				PlayerTwoGraveyard.RemoveToGraveyard(piece);
			else
				throw new System.Exception("ERROR : Piece is send in NONE Camp");
		}



		private Graveyard m_playerOneGraveyard;
		private Graveyard m_playerTwoGraveyard;
	}

}