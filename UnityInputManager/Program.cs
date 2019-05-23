using UnityInputManager.Helpers;

namespace UnityInputManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InputManagerBuider inputManagerBuider = new InputManagerBuider(4);
            inputManagerBuider.Add(new XboxOneGamepad());
            inputManagerBuider.Builder();

        }
    }
}
