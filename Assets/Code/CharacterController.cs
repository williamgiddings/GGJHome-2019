using UnityEngine;

//Null is used for the transition.
public enum CharType
{
    Null = 0,
    Child = 1,
    Parent = 2
}

public class CharacterController : MonoBehaviour
{
    CharType m_CurrentChar = CharType.Null;
    GameObject m_CurrentObject = null;

    public GameObject ParentCharacter = null;
    public GameObject ChildCharacter = null;
    public float MoveSpeed = 0.1f;

    void Start()
    {
        //make sure both character gameobjects are linked.
        Debug.Assert(ParentCharacter != null, "ParentController was null!", ParentCharacter);
        Debug.Assert(ChildCharacter != null, "ChildCharacter was null!", ChildCharacter);

        //temp
        m_CurrentChar = CharType.Parent;
        UpdateController();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        //debug, remove later.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_CurrentChar = CharType.Child;
            UpdateController();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_CurrentChar = CharType.Parent;
            UpdateController();
        }

        var pos = m_CurrentObject.transform.position;

        if (Input.GetAxis("Vertical") < 0.0f)
            pos.z -= MoveSpeed;

        if (Input.GetAxis("Vertical") > 0.0f)
            pos.z += MoveSpeed;

        if (Input.GetAxis("Horizontal") < 0.0f)
            pos.x -= MoveSpeed;

        if (Input.GetAxis("Horizontal") > 0.0f)
            pos.x += MoveSpeed;

        m_CurrentObject.transform.position = pos;
    }

    void UpdateController()
    {
        //Disable both character, and then check the currentchar against the enums and then set active respectively.
        ParentCharacter.SetActive(false);
        ChildCharacter.SetActive(false);

        switch (m_CurrentChar)
        {
            //hacky but ehh.
            case CharType.Child:
                ChildCharacter.SetActive(true);
                m_CurrentObject = ChildCharacter;
                break;
            case CharType.Parent:
                ParentCharacter.SetActive(true);
                m_CurrentObject = ParentCharacter;
                break;
            default:
                Debug.LogWarning("Oops, wasn't child nor parent!");
                break;
        }
    }
}
