namespace _Project._Scripts.Core.Input
{
    public interface IInputHandler
    {
        public InputState State { get; }
        public void Enable();
        public void Disable();
    }
}