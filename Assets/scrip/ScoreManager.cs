using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text MoneyTotal;
    [SerializeField] private int Score;
    [SerializeField] private Player player;
    private void OnEnable()
    {
        player.RecoletMoney += UpdateMoney;
    }

    private void OnDisable()
    {
        player.RecoletMoney -= UpdateMoney;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMoney()
    {
        Score = Score + 1;
        MoneyTotal.text = "X "+ Score.ToString();
    }
}
