using TinyRoar.Framework;

class UserService : IUserService
{
    [Inject]
    public DoBlaSignal DoBlaSignal { get; set; }

    [Inject]
    public DoBlubbSignal DoBlubbSignal { get; set; }

    [Inject]
    public IUser CurrentUser { get; set; }

    public void UpdateNickname(string source)
    {
        if (source == "Bla")
        {
            DoBlaSignal.Dispatch();
        }
        else
        {
            DoBlubbSignal.Dispatch();
        }
    }

}
