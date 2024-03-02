using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;
using YokaiNoMori.Interface;


public static class MovementValidator
{
    public static bool CheckMovement(IPawn pawn, Vector2 newPosition, int maxX, int maxY, int minX = 0, int minY = 0)
    {
        if (newPosition.x < minX || newPosition.x >= maxX || newPosition.y < minY || newPosition.y >= maxY) return false;

        IBoardCase currentCase = pawn.GetCurrentBoardCase();
        if (currentCase is null) return false;



        List<Vector2> validPosition = new List<Vector2>();
        Vector2 currentPosition = currentCase.GetPosition();
        int orientation = GameManager.Instance.GetOrientationFromPawn(pawn);
        

        foreach (Vector2 direction in pawn.GetDirections())
        {
            validPosition.Add(currentPosition + (direction * orientation)); // A VERIFIER
        }

        return validPosition.Contains(newPosition);
    }

    public static bool CheckParachutage(Piece piece, Vector2 newPosition, int maxX, int maxY, int minX = 0, int minY = 0)
    {
        if (newPosition.x < minX || newPosition.x > maxX || newPosition.y < minY || newPosition.y > maxY) return false;

        if (piece.CurrentBoardCase is null)
        {
            if (GameManager.Instance.BoardManager.GetBoardCase(newPosition).GetPawnOnIt() is null)
            {
                return true;
            }
        }
        return false;
    }

}
