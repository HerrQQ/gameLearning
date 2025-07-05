using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatfromShoot
{
    public class CameraCtrl : MonoBehaviour
    {
        private Transform mTarget;
        private void Start()
        {
            mTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            transform.localPosition = new Vector3(mTarget.position.x, mTarget.position.y, -100);
        }
    }
}

