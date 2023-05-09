using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    //씬의 인덱스 번호 지정
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewgame()
    {
        NewGameScene();
    }
    public void OnClickLoad()
    {
        print("불러오기");
    }
    public void OnClickQuit()
    {
        //유니티에서는 동작하지 않기 때문에 전처리기 지시문(공부할것)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //씬 전환
    public void NewGameScene()
    {
        //빌드시킨 mainscene이 0번 그 이후로 +1번
        SceneManager.LoadScene(sceneIndex + 1);
    }


}
