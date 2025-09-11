using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
   public Rigidbody rigidbody;
   public float speed = 7;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.forward = hitPoint - transform.position;
        }
       
        transform.position += GetImput() * speed * Time.deltaTime;
        //rigidbody.velocity = GetImput() * speed;


    }

    Vector3 GetImput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
