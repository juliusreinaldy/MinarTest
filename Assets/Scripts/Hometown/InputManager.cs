using System;
using UnityEngine;

namespace Project.Hometown
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnInputTouch;

        private HouseView houseView;
        private HouseController houseController;
        public void ClickUpgrade()
        {
            houseView = GameObject.Find("GameWorld").GetComponent<HouseView>();
            houseController = houseView.GetHouseController();

            int tempLevel;
            int tempMaxLevel;

            houseController.SentUpData(out tempLevel, out tempMaxLevel);

            LevelupEventData newData;
            houseView.HandleOnHouseLevelUp(newData = new LevelupEventData(tempLevel, tempMaxLevel));

            OnInputTouch?.Invoke();
        }
    }
}