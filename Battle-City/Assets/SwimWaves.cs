using UnityEngine;

public class SwimWaves : MonoBehaviour
{
    public Renderer targetRenderer; // Renderer bileþenini buraya atayýn
    public float speed = 0.01f;     // Temel artýþ miktarý
    public float chanceToIncreaseBy100 = 0.5f; // %100 ile artýrma þansý (0.5 = %50 þans)

    private Material material;
    private Vector2 offset;

    void Start()
    {
        // Renderer'dan materyali al
        material = targetRenderer.material;
        offset = material.mainTextureOffset; // Mevcut offset deðerini al
    }

    void Update()
    {
        // Dinamik artýþ miktarýný belirle
        float currentSpeed = Random.value < chanceToIncreaseBy100 ? speed : speed * 0.3f;

        // Offset'in y deðerini artýr
        offset.y += currentSpeed * Time.deltaTime; // Daha yumuþak hareket için Time.deltaTime ile ölçekle
        material.mainTextureOffset = offset; // Yeni offset'i uygula
    }
}
