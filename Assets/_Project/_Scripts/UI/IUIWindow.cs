namespace _Project._Scripts.UI
{
    public interface IUIWindow
    {
        public void Init(UIManager uiManager);
        public void Show();
        public void Hide();
    }
}