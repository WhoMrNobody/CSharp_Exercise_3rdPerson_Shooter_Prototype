
namespace UdemyProject3.Abstract.States
{
    public interface IState
    {
        void Tick();
        void OnEnter();
        void OnExit();
        void TickFixed();
        void TickLate();
    }
}

