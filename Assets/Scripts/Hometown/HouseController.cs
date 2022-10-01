using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable , ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        private event Action<UpgradeableData> upData;
        public event Action TriggerSpawn;


        private HometownContext _hometownContext;
        private string _itemName;
        private UpgradeableData _upgradeableData;
        private UpgradeableRepository _upgradeRepo;
        public void OnContextDispose()
        {
            //add implementation
        }

        public HouseController(HometownContext hometownContext , string upgradeableItemName , InputManager inputManager)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;

            //add implementation
        }

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");
            //add implementation
        }

        public void HandleOnInputTouch()
        {
            //add implementation
            _upgradeableData.LevelUp();
        }

        public void CreateUpData()
        {
            upData = new Action<UpgradeableData>(GetUpData);
            _upgradeRepo = new UpgradeableRepository(_hometownContext);
            _upgradeRepo.GetUpgradeableData(upData);

        }

        public void GetUpData(UpgradeableData tempUp)
        {
            _upgradeableData = tempUp;

            Debug.Log("Value Of Level: " + _upgradeableData.Level);
            Debug.Log("Value Of MaxLevel: " + _upgradeableData.MaxLevel);
        }

        public void SentUpData(out int level, out int maxLevel)
        {
            level = _upgradeableData.Level;
            maxLevel = _upgradeableData.MaxLevel;
        }

        public void LevelUp()
        {
            _upgradeableData.LevelUp();
        }
        


    }
}