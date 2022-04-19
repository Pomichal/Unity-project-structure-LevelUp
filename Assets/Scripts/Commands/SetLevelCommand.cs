public class SetLevelCommand : ICommand
{

    private string levelName;

    public SetLevelCommand(string levelName)
    {
        this.levelName = levelName;
    }

    public void Execute()
    {
        App.levelManager.SetLevel(levelName);
    }
}
