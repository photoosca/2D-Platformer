using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player;
    public Transform Bg1;
    public Transform Bg2;
    public Transform Bg3;

    // Use this for initialization
    void Start()
    {
        /*blyt.xcl
            hd.*/
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y != transform.position.y && player.position.y > 0 && player.position.y < 30f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.position.y, transform.position.z), 0.1f);
        }
        Bg1.transform.position = new Vector2(transform.position.y * 1.0f, Bg1.transform.position.x);
        Bg2.transform.position = new Vector2(transform.position.x * 0.8f, Bg2.transform.position.y);
        Bg3.transform.position = new Vector2(transform.position.x * 0.6f, Bg3.transform.position.y);

    }
}