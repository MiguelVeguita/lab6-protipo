using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CoinBehaviour : MonoBehaviour
{
    [Header("Rotación")]
    [SerializeField] public float rotateSpeed = 100f;

    [Header("Animación de recogida")]
    [SerializeField] public float collectDuration = 0.5f;
    [SerializeField] public float moveUpDistance = 1f;

    private bool collected = false;
    private Vector3 originalPosition;

    [SerializeField] private Player player;
    private void OnEnable()
    {
        player.RecoletMoney += DestruirMoneda;
        
    }

    private void OnDisable()
    {
        player.RecoletMoney -= DestruirMoneda;
        
    }

    void Update()
    {
        if (!collected)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }
    }
    public void DestruirMoneda()
    {
        collected = true;
        originalPosition = transform.position;
        GetComponent<Collider>().enabled = false; 
        StartCoroutine(CollectAnimation());
    }

    void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;
            originalPosition = transform.position;
            GetComponent<Collider>().enabled = false;  
            StartCoroutine(CollectAnimation());
        }
    }

    private IEnumerator CollectAnimation()
    {
        float elapsed = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        Vector3 startPos = originalPosition;
        Vector3 endPos = originalPosition + Vector3.up * moveUpDistance;

        while (elapsed < collectDuration)
        {
            float t = elapsed / collectDuration;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
        transform.position = endPos;

        Destroy(this.gameObject);
    }
}
