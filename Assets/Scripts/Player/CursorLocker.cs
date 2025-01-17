using UnityEngine;

namespace Player
{
    public class CursorLocker
    {
        public static bool Locked
        {
            get => Locked;
            set
            {
                if (value)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }

                Locked = value;
            }
        }
    }
}