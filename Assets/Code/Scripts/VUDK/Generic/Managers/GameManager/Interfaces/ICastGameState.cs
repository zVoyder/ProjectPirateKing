namespace VUDK.Generic.Managers.GameManager.Interfaces
{
    public interface ICastGameState<T> where T : GameState
    {
        public T CastedGameState { get; }
    }
}
