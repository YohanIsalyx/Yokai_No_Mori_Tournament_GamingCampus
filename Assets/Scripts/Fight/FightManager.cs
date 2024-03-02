using YokaiNoMori.Interface;

public class FightManager
{
    public void DoFight(IPawn attack, IPawn defense)
    {

        // SI KOROPOKKURU ==> DEFAITE
        // SINON SI PIECE EVOLUEE => DIVOLVE
        // SINON SEND TO GRAVEYARD
        GameManager.Instance.GraveyardManager.SendToGraveyard(defense, attack.GetCurrentOwner());
    }
}
