using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class InteractChar : MonoBehaviour
    {
        public Camera Cam;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;

            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            Debug.DrawRay(Cam.transform.position, Cam.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.isTrigger)
                {
                    Debug.Log("Hitting Collider " + hit.collider.gameObject.name);
                }
                if (hit.collider.isTrigger && Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<DoorManager>().PlayAnimation();
                }
            }
        }
    }
}
