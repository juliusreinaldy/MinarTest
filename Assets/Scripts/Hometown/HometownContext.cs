using Project.Components;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Project.Hometown
{
    [RequireComponent(typeof(InputManager) , typeof(Spawner))]
    public class HometownContext : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private Spawner _spawner;

        public HouseController HouseController { get; private set; }

        private HouseView _houseView;
        

        private void Awake()
        {
            if(_inputManager == null)
            {
                _inputManager = GetComponent<InputManager>();
            }

            if (_spawner == null)
            {
                _spawner =  GetComponent<Spawner>();
            }

            _houseView = GameObject.Find("GameWorld").GetComponent<HouseView>();
            HouseController = new HouseController(gameObject.GetComponent<HometownContext>(),"House",_inputManager);
            HouseController.CreateUpData();

           

            _houseView.Setup(HouseController);
            //add implementation
        }

        private void OnDestroy()
        {
            //add implementation
        }
    }
}