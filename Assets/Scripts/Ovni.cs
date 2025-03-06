using UnityEngine;

public class Ovni : MonoBehaviour
{
    public delegate void OvniDied(int points);
    public static event OvniDied OnOvniDie;
    
    public float movespeed = 3f;
    private Vector3 spawn;
    private Vector3 destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = new Vector3(-9.5f, 4.5f, 0f);
        destination = new Vector3(9.5f, 4.5f, 0f);
        transform.position = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, movespeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        OnOvniDie?.Invoke(50);
        Destroy(gameObject);
    }
}
