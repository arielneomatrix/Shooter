using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    private Shotter _player;
    
    private void Start()
    {
        _player = FindObjectOfType<Shotter>();
    }



    // Update is called once per frame
    void Update()
    {
        // Ensure _player.transform is cast to Transform to access the position property
        if (_player != null && _player.transform is Transform playerTransform)
       
            transform.forward = playerTransform.position - transform.position;
            transform.position += transform.forward * 1 * Time.deltaTime;
       
    }


     private void OnCollisionEnter(Collision collision)
     {
            if (collision.gameObject.GetComponent<Balas>())
            {
            Destroy(gameObject);
            Destroy(collision.gameObject);
             }

     }
    
}

