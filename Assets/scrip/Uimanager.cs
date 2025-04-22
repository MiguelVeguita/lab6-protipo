using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Uimanager : MonoBehaviour
{
    [SerializeField] private TMP_Text puntaje;
    
    [SerializeField] private Player player;

    private int puntos;
    private void OnEnable()
    {
        player.RecoletMoney += updatePuntaje;

    }

    private void OnDisable()
    {
        player.RecoletMoney -= updatePuntaje;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void updatePuntaje()
    {
        puntos = puntos + 100;
        puntaje.text=puntos.ToString();
    }
}
