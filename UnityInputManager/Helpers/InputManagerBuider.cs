using System;
using System.Collections.Generic;
using System.IO;

namespace UnityInputManager.Helpers
{
    public class InputManagerBuider
    {
        private List<IGamepad> m_GamepadList = new List<IGamepad>();

        public void Add(IGamepad gamepad)
        {
            m_GamepadList.Add(gamepad);
        }

        public readonly string Filename = "InputManager.asset";

        public int PlayerNumbers { get; private set; }

        public InputManagerBuider(int playerNumbers)
        {
            PlayerNumbers = playerNumbers;
        }

        public void Builder()
        {
            try
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }

                using (StreamWriter writer = File.CreateText(Filename))
                {
                    writer.WriteLine("%YAML 1.1");
                    writer.WriteLine("%TAG !u! tag:unity3d.com,2011: ");
                    writer.WriteLine("--- !u!13 &1");
                    writer.WriteLine("InputManager:");
                    writer.WriteLine("  m_ObjectHideFlags: 0");
                    writer.WriteLine("  serializedVersion: 2");
                    writer.WriteLine("  m_Axes:");

                    foreach (var gamepad in m_GamepadList)
                    {
                        gamepad.Builder(writer, PlayerNumbers);
                    }

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}