using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject[] characters = new GameObject[1];
    GameObject selectedCharacter;
    int selectedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = GameObject.Instantiate(characters[selectedIndex]);
        selectedCharacter.GetComponent<Rigidbody>().useGravity = false;
        selectedCharacter.transform.Find("PlayerCanvas").gameObject.SetActive(false);

        selectedCharacter.transform.position = new Vector3(0.5f, -120f, -15f);
        selectedCharacter.transform.rotation = Quaternion.Euler(0, 180, 0);
        selectedCharacter.transform.localScale = new Vector3(80, 80, 80);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
