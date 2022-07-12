using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUi : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        bestScoreText.text = $"Best Score: {DataManager.Instance.bestPlayerName}: {DataManager.Instance.bestScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
