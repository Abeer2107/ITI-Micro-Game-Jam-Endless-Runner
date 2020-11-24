using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    [SerializeField] public float scrollSpeed = 0.1f;
    private Renderer thisRenderer;

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        thisRenderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }
}
