using System;
using System.IO;

namespace UnityInputManager.Helpers
{
    public class XboxOneGamepad : IGamepad
    {
        public enum XboxOneGamepadAxis
        {
            LeftStickHorizontal = 0,
            LeftStickVertical = 1,
            RightStickHorizontal = 3,
            RightStickVertical = 4,
            DPADHorizontal = 5,
            DPADVertical = 6,
            LeftTrigger = 8,
            RightTrigger = 9,
        }

        public enum XboxOneGamepadButton
        {
            ButtonY = 3,
            ButtonB = 1,
            ButtonA = 0,
            ButtonX = 2,
            LeftBumper = 4,
            RightBumper = 5,
            StartButton = 7,
            BackButton = 6,
            LeftStickClick = 8,
            RightStickClick = 9
        }

        public void Builder(StreamWriter writer, int playerNumbers)
        {
            for (int joyNum = 1; joyNum <= playerNumbers; joyNum++)
            {
                foreach (string axisName in Enum.GetNames(typeof(XboxOneGamepadAxis)))
                {
                    writer.WriteLine($"  - serializedVersion: 3");
                    writer.WriteLine($"    m_Name: XboxOne{axisName}{joyNum}");
                    writer.WriteLine($"    descriptiveName: ");
                    writer.WriteLine($"    descriptiveNegativeName:");
                    writer.WriteLine($"    negativeButton:");
                    writer.WriteLine($"    positiveButton:");
                    writer.WriteLine($"    altNegativeButton:");
                    writer.WriteLine($"    altPositiveButton:");
                    writer.WriteLine($"    gravity: 1");
                    writer.WriteLine($"    dead: 0.2");
                    writer.WriteLine($"    sensitivity: 1");
                    writer.WriteLine($"    snap: 0");
                    writer.WriteLine($"    invert: {(axisName.Contains("StickVertical") ? 1 : 0)}");
                    writer.WriteLine($"    type: 2");
                    writer.WriteLine($"    axis: {(int)Enum.Parse(typeof(XboxOneGamepadAxis), axisName)}");
                    writer.WriteLine($"    joyNum: {joyNum}");
                }

                foreach (string buttonName in Enum.GetNames(typeof(XboxOneGamepadButton)))
                {
                    writer.WriteLine($"  - serializedVersion: 3");
                    writer.WriteLine($"    m_Name: XboxOne{buttonName}{joyNum}");
                    writer.WriteLine($"    descriptiveName: ");
                    writer.WriteLine($"    descriptiveNegativeName:");
                    writer.WriteLine($"    negativeButton:");
                    writer.WriteLine($"    positiveButton: joystick {joyNum} button {(int)Enum.Parse(typeof(XboxOneGamepadButton), buttonName)}");
                    writer.WriteLine($"    altNegativeButton:");
                    writer.WriteLine($"    altPositiveButton:");
                    writer.WriteLine($"    gravity: 1000");
                    writer.WriteLine($"    dead: 0.001");
                    writer.WriteLine($"    sensitivity: 1000");
                    writer.WriteLine($"    snap: 0");
                    writer.WriteLine($"    invert: 0");
                    writer.WriteLine($"    type: 0");
                    writer.WriteLine($"    axis: 0");
                    writer.WriteLine($"    joyNum: {joyNum}");
                }
            }
        }
    }
}
