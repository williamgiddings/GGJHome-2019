using UnityEngine;

public enum EnumCharTypes
{
    Null = 0,
    Child,
    Parent
}

public class CharManager : MonoBehaviour
{
    private EnumCharTypes m_CurrentType;

    public GameObject ParentObject;
    public GameObject ChildObject;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ParentObject != null, "Parent Object is null", ParentObject);
        Debug.Assert(ChildObject != null, "Child Object is null", ChildObject);

        m_CurrentType = EnumCharTypes.Parent;
        HandleCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_CurrentType = EnumCharTypes.Child;
            HandleCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_CurrentType = EnumCharTypes.Parent;
            HandleCharacter();
        }
    }

    void HandleCharacter()
    {
        ChildObject.SetActive(false);
        ParentObject.SetActive(false);

        switch (m_CurrentType)
        {
            case EnumCharTypes.Child:
                ChildObject.SetActive(true);
                break;
            case EnumCharTypes.Parent:
                ParentObject.SetActive(true);
                break;
            default:
                Debug.LogWarning("Unknown enum value passed");
                break;
        }
    }
}
