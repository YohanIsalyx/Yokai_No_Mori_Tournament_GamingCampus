using UnityEngine;
using YokaiNoMori.Enumeration;


namespace YokaiNoMori.Interface
{
    public interface IAction
    {
        public void DoAction(Vector2 positionReached, EActionType actionType);


    }
}
