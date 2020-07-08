using strange.extensions.command.impl;

public sealed class LoginCommand : Command
{
    // parameter
    [Inject]
    public string Source { get; set; }

    [Inject]
    public IUserService UserService { get; set; }

    public override void Execute()
    {
        this.UserService.UpdateNickname(Source);
    }

}