using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        private Spawner _Spawner;

        private bool isMove = false;
        public void SetDestination(Vector3 destination, GameObject thatGameObject)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)

            StartCoroutine(MoveWithDelay(destination, thatGameObject, 10.0f));
        }

        private IEnumerator MoveWithDelay(Vector3 tempVector, GameObject tempObject, float duration)
        {
            //yield return new WaitForSeconds(3.0f);
            if (isMove)
            {
                yield break;
            }

            isMove = true;
            float counter = 0;

            Vector3 startPos = tempObject.transform.position;
            while (counter < duration)
            {
                Debug.Log("Moving");
                counter += Time.deltaTime;
                tempObject.transform.position = Vector3.Lerp(startPos, tempVector, counter / duration);

                yield return null;
                //thisGameObject.transform.position = new Vector3(thisGameObject.transform.position.x + 0.1f, thisGameObject.transform.position.y, thisGameObject.transform.position.z);
            }

            isMove = false;

            if (tempObject.transform.position.x == tempVector.x)
            {
                _Spawner = GameObject.Find("GameWorld").GetComponent<Spawner>();
                _Spawner.DestroySpawnedObject(tempObject);
            }
        }
    }
}