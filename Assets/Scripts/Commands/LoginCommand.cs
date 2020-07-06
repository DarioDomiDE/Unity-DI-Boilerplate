using strange.extensions.command.impl;

public sealed class LoginCommand : Command
{
    [Inject]
    public IUserService UserService { get; set; }

    public override void Execute()
    {
        this.UserService.UpdateNickname("Fb User");
    }

}