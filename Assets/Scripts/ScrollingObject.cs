using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField] bool doScroll = true;
    [SerializeField] float scrollSpeed = 10;
    private Rigidbody2D rb2d;

    public delegate void PlayerHitEvent();
    public static event PlayerHitEvent PlayerHit;

    private void OnEnable()
    {
        GameManager.UpdateDifficulty += UpdateScrollSpeed;
    }
    private void OnDisable()
    {
        GameManager.UpdateDifficulty -= UpdateScrollSpeed;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(-20 * scrollSpeed, 0);
    }

    void Update()
    {
        if (!doScroll)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHit.Invoke();
        }
    }

    void UpdateScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
}
