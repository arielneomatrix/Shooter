using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shotter : MonoBehaviour
{
   public Balas balasPrefab;
   public new Rigidbody rigidbody;
   public Transform spawnPoint;
   
   public float speed = 7;
    //public LayerMask groundLayer;
   public SkinnedMeshRenderer meshRenderer;
   public bool _canGetHit = true;
   public float _noHitTime = 2;
   public IUManager iuManager;
   public int vidas = 5;
   public int puntos;

    private void Start()
    {
     
        iuManager.SetNewLife(vidas);
       
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        //", 1000, groundLayer" usar este codigo arriga si se quiere que solo apunte al suelo.
        {

            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.forward = hitPoint - transform.position;
        }

        transform.position += GetImput() * speed * Time.deltaTime;
        //rigidbody.velocity = GetImput() * speed;

        if (Input.GetMouseButtonDown(0))
        {

            Balas balas = Instantiate(balasPrefab);
            balas.transform.position = spawnPoint.position;
            balas.transform.forward = transform.forward;

        }

        if (!_canGetHit)
        {
            _noHitTime -= Time.deltaTime;
          if(_noHitTime < 0)
          {
               _canGetHit = true;
               Material  material = new Material(meshRenderer.material);
               material.color = Color.white;
               meshRenderer.material = material;
               _noHitTime = 2;
          }

        }

    }
         

    Vector3 GetImput()
     {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
     }
    private void OnCollisionEnter(Collision collision)

    {   
        if (collision.gameObject.GetComponent<ZombieEnemy>())
        {
            puntos+=100;
            iuManager.Setscore(puntos);
            _canGetHit = false;
            Material material = new Material(meshRenderer.material);
            material.color = Color.gray;
            meshRenderer.material = material;
           
            vidas--;
            iuManager.SetNewLife(vidas);
            if (vidas <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

                Destroy(collision.gameObject);
        }

    }
}

