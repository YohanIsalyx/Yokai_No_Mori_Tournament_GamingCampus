using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using YokaiNoMori.Interface;

public class Graveyard
{
    private List<IPawn> m_pieces;

    public List<IPawn> Pieces
    {
        get { return m_pieces; }
        private set { m_pieces = value; }
    }


    public void Init()
    {
        Pieces = new List<IPawn>();
    }


    public void AddToGraveyard(IPawn parachutableObject)
    {
        Pieces.Add(parachutableObject);
    }

    public void RemoveToGraveyard(IPawn parachutableObject)
    {
        Pieces.Remove(parachutableObject);
    }
}
