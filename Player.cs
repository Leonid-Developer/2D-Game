using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public UI UI;

    public static int score;

    public static List<Square> squares;
    private void Awake()
    {
        squares = new List<Square>();
    }

    private void Update()
    {
        if (squares.Count == 0)
        {
            Victory();
        }
    }

    public static void Defeat()
    {
        UI.ShowDefeatPanel();
        score = 0;
    }
    public static void Victory()
    {
        UI.ShowVictoryPanel();
    }

    public static void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
