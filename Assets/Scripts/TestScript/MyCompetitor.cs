using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YokaiNoMori.Enumeration;

public class MyCompetitor : Competitor
{
    public override void Init(ECampType camp)
    {
        Camp = camp;
    }

    public override void StartTurn()
    {
        Debug.Log("It's my turn !");
    }

    public override void StopTurn()
    {
        Debug.Log("I finish my turn !");
    }
}
