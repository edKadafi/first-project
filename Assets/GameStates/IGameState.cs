
public interface IGameState
{
    public string StateName  { get; }
    public bool isRunning { get; }
    public bool isSuspended { get; }

    void Suspend();
    void Resume();
    
    //Handling for entering the gamestate
    void StateEnter();

    //Handling for exiting the gamestate
    void StateExit();
}
