using System;
using UnityEngine;

public class PlayerObserve : MonoBehaviour
{
        public static Action<int> OnCoinsChanged;

        public static void NotifyCoinsChanged(int totalCoins)
        {
            OnCoinsChanged?.Invoke(totalCoins);
        }
       
}
