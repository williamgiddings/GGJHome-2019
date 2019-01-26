using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CharacterManager;
    public GameObject DoorMaster;
    public UIManager uiManager;

    public Camera PrologueCamera;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        CharacterManager.SetActive(false);
        PrologueCamera.enabled = true;
        uiManager.SetObjectiveText("The evil has appeared!");
        yield return StartCoroutine(PrologueCameraScene(2.0F));
        //uiManager.SetObjectiveText("");
        CharacterManager.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PrologueCameraScene(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
