namespace VUDK.Generic.Managers.GameManagers.Interfaces
{
    public interface ICastGameManager<T> where T : GameManager
    {
        public T GameManager { get; }
    }
}
