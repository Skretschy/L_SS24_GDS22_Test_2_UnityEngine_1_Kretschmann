using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public static Logic Instance { get; private set; }
    public GameObject doneScreen;
    private ApplePieces[] applePieces;
    public void TrumpScene()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void DeactivateAnimator()
    {
        GameObject.Find("Trump_Run").GetComponent<Animator>().enabled = false;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        applePieces = FindObjectsOfType<ApplePieces>();
    }
    public void CheckAllPieces()
    {
        foreach (var piece in applePieces)
        {
            if (!piece.inRightPosition || !piece.inRightRotation)
            {
                return;
            }
        }
        doneScreen.SetActive(true);
    }
}
