using UnityEngine;

public class SwimWaves : MonoBehaviour
{
    public Renderer targetRenderer; // Renderer bile�enini buraya atay�n
    public float speed = 0.01f;     // Temel art�� miktar�
    public float chanceToIncreaseBy100 = 0.5f; // %100 ile art�rma �ans� (0.5 = %50 �ans)

    private Material material;
    private Vector2 offset;

    void Start()
    {
        // Renderer'dan materyali al
        material = targetRenderer.material;
        offset = material.mainTextureOffset; // Mevcut offset de�erini al
    }

    void Update()
    {
        // Dinamik art�� miktar�n� belirle
        float currentSpeed = Random.value < chanceToIncreaseBy100 ? speed : speed * 0.3f;

        // Offset'in y de�erini art�r
        offset.y += currentSpeed * Time.deltaTime; // Daha yumu�ak hareket i�in Time.deltaTime ile �l�ekle
        material.mainTextureOffset = offset; // Yeni offset'i uygula
    }
}
