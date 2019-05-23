using System.IO;

namespace UnityInputManager.Helpers
{
    public interface IGamepad
    {
        void Builder(StreamWriter writer, int playerNumbers);
    }
}
