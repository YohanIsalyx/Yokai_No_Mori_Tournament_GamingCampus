using System;
using UnityEngine;
using YokaiNoMori.Interface;

public class MovementManager
{
    public void DoMovement(IPawn pawn, Vector2 newPosition)
    {
        GameManager.Instance.BoardManager.GetBoardCase(newPosition);

        // TODO
        // Faire le mouvement uniquement. Et s'il y a une autre pi�ce, l'envoyer dans le fight manager

        // Cr�er �galement le parachuteManager pour le parachutage
    }
}
