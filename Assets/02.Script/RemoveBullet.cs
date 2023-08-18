using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;
    void OnCollisionEnter(Collision coll) {
        //if(coll.collider.tag == "BULLET"){
        if(coll.collider.CompareTag("BULLET")){
            //Instantiate(sparkEffect,coll.transform.position,Quaternion.identity);
            ContactPoint cp = coll.GetContact(0);
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            GameObject spark = Instantiate(sparkEffect,cp.point,rot);

            //Instantiate(sparkEffect,cp.point,rot);

            Destroy(spark, 1f);

            Destroy(coll.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
