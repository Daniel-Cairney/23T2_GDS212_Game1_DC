using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DanielCairney
{


    public class CameraHolder : MonoBehaviour
    {
        public Transform cameraPosition;
       
        private void Update()
        {
            transform.position = cameraPosition.position;
        }
    }
}