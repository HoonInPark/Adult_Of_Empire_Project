using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;
    [Range(2.0f,20.0f)]
    public float distance = 10.0f;
    [Range(0.0f,10.0f)]
    public float height = 2.0f;
    public float damping = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public float targetOffset = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        camTr = GetComponent<Transform>();
    }
    void LateUpdate() {
    //     camTr.position = targetTr.position + (-targetTr.forward * distance)
    //         + (Vector3.up*height);

        Vector3 pos = targetTr.position + (-targetTr.forward * distance)
                + (Vector3.up*height);

        // camTr.position = Vector3.Slerp(camTr.position,pos,
        //         Time.deltaTime*damping);

        camTr.position = Vector3.SmoothDamp(camTr.position,
                pos,ref velocity,damping);

        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
