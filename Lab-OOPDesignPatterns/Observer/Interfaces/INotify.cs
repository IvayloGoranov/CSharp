using Skyrim.Units;

namespace Skyrim.Interfaces
{
    public interface INotify
    {
        void Attach(IDragonDeathObserver unit);

        void Detach(IDragonDeathObserver unit);

        void Notify();
    }
}
