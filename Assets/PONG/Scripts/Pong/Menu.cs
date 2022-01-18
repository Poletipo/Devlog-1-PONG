using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


    public void LoadPlayerScene()
    {
        PassedData.playerIndexes[0] = 0;
        PassedData.playerIndexes[1] = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadAIScene()
    {
        PassedData.playerIndexes[0] = 0;
        PassedData.playerIndexes[1] = 2;
        SceneManager.LoadScene(1);
    }

    public void LoadAIvsAIScene()
    {
        PassedData.playerIndexes[0] = 2;
        PassedData.playerIndexes[1] = 2;
        SceneManager.LoadScene(1);
    }


}
