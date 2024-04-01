using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services
{
    public interface IAsyncState : IState
    {
        new UniTask Enter();
        new UniTask Exit();
    }
}