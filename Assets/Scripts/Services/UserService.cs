using TinyRoar.Framework;

class UserService : IUserService
{
    [Inject]
    public LoggedInSignal LoggedInSignal { get; set; }

    [Inject]
    public IUser CurrentUser { get; set; }

    public void UpdateNickname(string nickname)
    {
        Print.Log("Service triggered");
        this.CurrentUser.Nickname = nickname;
        LoggedInSignal.Dispatch(nickname);
    }
}
