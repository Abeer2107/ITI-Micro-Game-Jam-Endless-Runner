using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public delegate void PlayerOutOfBoundEvent();
    public static event PlayerOutOfBoundEvent PlayerOutOfBound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerOutOfBound.Invoke();
        }

        if (collision.gameObject.transform.parent)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
