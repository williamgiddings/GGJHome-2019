using UnityEngine;
using UnityEngine.UI;

namespace Home
{
    public enum EnumCharTypes
    {
        Null = 0,
        Child,
        Parent
    }

    public class CharManager : MonoBehaviour
    {
        private EnumCharTypes m_CurrentType;
        private Camera m_Camera;

        public GameObject ParentObject;
        public GameObject ChildObject;
        public EnumCharTypes StartingChar;
        public Text InteractLabel;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(ParentObject != null, "Parent Object is null", ParentObject);
            Debug.Assert(ChildObject != null, "Child Object is null", ChildObject);
            Debug.Assert(InteractLabel != null, "Interact Label is null", InteractLabel);

            m_CurrentType = StartingChar;
            HandleCharacter();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                m_CurrentType = EnumCharTypes.Child;
                HandleCharacter();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                m_CurrentType = EnumCharTypes.Parent;
                HandleCharacter();
            }
            HandleInteractions();
        }

        void HandleCharacter()
        {
            ChildObject.SetActive(false);
            ParentObject.SetActive(false);

            switch (m_CurrentType)
            {
                case EnumCharTypes.Child:
                    ChildObject.SetActive(true);
                    m_Camera = ChildObject.GetComponentInChildren<Camera>();
                    break;
                case EnumCharTypes.Parent:
                    ParentObject.SetActive(true);
                    m_Camera = ParentObject.GetComponentInChildren<Camera>();
                    break;
                default:
                    Debug.LogWarning("Unknown enum value passed");
                    break;
            }
        }

        void HandleInteractions()
        {
            RaycastHit hit;
            Ray ray = new Ray(m_Camera.transform.position, m_Camera.transform.forward);
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
