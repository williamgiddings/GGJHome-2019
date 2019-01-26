using UnityEngine;
using UnityEngine.UI;

namespace Home
{
    public class InteractChar : MonoBehaviour
    {
        public Camera Cam;
        public Text InteractLabel;

        void Start()
        {
            Debug.Assert(Cam != null, "Camera is null!");
        }

        void Update()
        {
            RaycastHit hit;

            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            Debug.DrawRay(Cam.transform.position, Cam.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.isTrigger)
                {
                    InteractLabel.text = hit.collider.gameObject.GetComponent<DoorManager>().Name;

                    if (Input.GetKeyDown(KeyCode.E))
                        hit.collider.gameObject.GetComponent<DoorManager>().PlayAnimation();
                }
                else
                {
                    InteractLabel.text = "";
                }
            }
        }
    }
}
