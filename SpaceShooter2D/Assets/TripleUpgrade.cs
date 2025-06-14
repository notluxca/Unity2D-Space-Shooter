using System;
using UnityEngine;

public class TripleUpgrade : MonoBehaviour
{
    public float speed = 5f;
    public static Action UpgradePickUp;

    private void Start()
    {
        Invoke("DestroySelf", 15f);
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UpgradePickUp?.Invoke();
            other.gameObject.GetComponent<ShootController>().ActivateTripleShot(10f);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
