using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Update()
    {
        var input = Input.inputString;

        switch (input)
        {
            case "":
                break;
            case "1":
                SceneManager.LoadScene(0);
                break;
            case "2":
                SceneManager.LoadScene(1);
                break;
            case "3":
                SceneManager.LoadScene(2);
                break;
            default:
                Print($"Incorrect key, <color=red>was pressed:</color> {input.ToUpper()}");
                break;
        }
    }

    private void Print(string msg)
    {
        Debug.Log(msg);
    }
}