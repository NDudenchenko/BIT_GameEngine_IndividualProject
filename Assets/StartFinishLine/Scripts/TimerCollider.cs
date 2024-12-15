using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCollider : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler CollideWithPlayer;
    public Collider PlayerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            CollideWithPlayer();
            Destroy(this.gameObject);
        }
    }
}
