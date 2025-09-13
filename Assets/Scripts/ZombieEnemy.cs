using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    private Shotter _player;
    public IUManager _iuManager;
    private void Start()
    {
        _player = FindObjectOfType<Shotter>();
        _iuManager = FindObjectOfType<IUManager>();  

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
                _player.puntos += 10;
                _iuManager.Setscore(_player.puntos);
                
            
            Destroy(gameObject);
            Destroy(collision.gameObject);
             }

     }
    
}

