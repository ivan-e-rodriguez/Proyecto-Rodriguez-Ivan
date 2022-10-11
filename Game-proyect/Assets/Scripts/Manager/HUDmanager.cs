using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour
{
    private static HUDmanager instance;
    public static HUDmanager Instance { get => instance; set => instance = value; }
    [SerializeField] GameObject livesPanel;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject winningPanel;
    [SerializeField] private Text selectedText;

    [SerializeField] GameObject player;


    void Start()
    {

    }
    void Update()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            PlayerCollision.OnDead += Refill;

            PlayerCollision.OnDead += GameOver;

            PlayerCollision.OnVictory += Winning;
        }
        else
        {
            Destroy(gameObject);
        }


    }


    public void SetScore(int newScore)
    {
        selectedText.text = newScore.ToString();
    }

    public static void GetDamage(int childIndex)
    {
        instance.livesPanel.transform.GetChild(childIndex).GetComponent<Image>().color = Color.black;
    }

    public static void GetHeal(int childIndex)
    {
        instance.livesPanel.transform.GetChild(childIndex).GetComponent<Image>().color = Color.white;
    }

    public static void Refill()
    {
        {
            instance.livesPanel.transform.GetChild(1).GetComponent<Image>().color = Color.white;
            instance.livesPanel.transform.GetChild(2).GetComponent<Image>().color = Color.white;
            instance.livesPanel.transform.GetChild(3).GetComponent<Image>().color = Color.white;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        player.SetActive(false);
    }

    private void Winning()
    {
        winningPanel.SetActive(true);
    }

    private void OnDisable()
    {
        PlayerCollision.OnDead -= Refill;
        PlayerCollision.OnDead -= GameOver;
        PlayerCollision.OnVictory -= Winning;
    }
}
