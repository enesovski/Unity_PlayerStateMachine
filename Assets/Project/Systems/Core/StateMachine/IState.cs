namespace Solivagant.Core
{
    public interface IState<T> where T : class
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}
