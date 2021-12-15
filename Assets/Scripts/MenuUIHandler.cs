using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;

    public TMP_Text title;

    private int highScore;

    private Color newColor;

    private void Awake()
    {
        SaveGame.LoadScore();
    }
    private void Start()
    {
        highScore = ScoreKeeper.highScore;
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            Color newColor = Random.ColorHSV();
            title.faceColor = Color.Lerp(title.faceColor, newColor, 0.3f);
          yield return new WaitForSeconds(0.1f);
           
        }        
    }

    public void SaveName()
    {
        ScoreKeeper.name = nameField.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        SaveGame.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
