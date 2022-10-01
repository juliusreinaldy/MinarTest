using UnityEngine;
using Project.Components;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {

        private HouseController _houseController;

        private Spawner _spawner;

        [SerializeField] GameObject houseObject;
        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }

        public HouseView Setup(HouseController houseController)
        {
            _houseController= houseController;
            return this;
        }

        public HouseController GetHouseController()
        {
            return _houseController;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            //add implementation
            if(data.Level <= data.MaxLevel)
            {
                houseObject.transform.localScale = new Vector3(houseObject.transform.localScale.x + 0.1f, houseObject.transform.localScale.y + 0.1f, houseObject.transform.localScale.z + 0.1f);
            }

            _houseController.LevelUp();

            if(data.Level == data.MaxLevel)
            {
                Debug.Log("Creating Tank");
                _spawner = GameObject.Find("GameWorld").GetComponent<Spawner>();
                _spawner.SpawnMoveableObject();

            }


        }
    }
}