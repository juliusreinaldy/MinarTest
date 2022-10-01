using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabObject;

        //[SerializeField]
        //private MoveableComponent _moveableComponent;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            //add implementation
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            //add implementation
        }

        public void SpawnMoveableObject()
        {
            Debug.Log("Ready To Spawn");
            //add implementation
            GameObject tempObj;

            tempObj = Instantiate(prefabObject);
            Vector3 endPoint = new Vector3(2.41f, tempObj.transform.position.y, tempObj.transform.position.z);

            tempObj.GetComponent<MoveableComponent>().SetDestination(endPoint,tempObj);
        }

        public void DestroySpawnedObject(GameObject usedObject)
        {
            Object.Destroy(usedObject);
        }

    }
}