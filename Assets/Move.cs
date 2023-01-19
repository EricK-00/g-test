using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    float s = 12;
    float rS = 90;

    float t = 0;
    float[] maxT = new float[3] {0.6f, 0.5f, 0.5f };
    Quaternion[] startRot = new Quaternion[3];
    Vector3[] startPos = new Vector3[3];
    public Transform[] endTransform = new Transform[3];
    int idx = 0;
    int maxIdx = 2;

    // Start is called before the first frame update
    void Start()
    {
        startRot[0] = transform.rotation;
        rb = GetComponent<Rigidbody>();
		//rb.velocity = -transform.up * s * Time.deltaTime;

		startPos[0] = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (maxIdx > idx && maxT[idx] <= t)
        {
            ++idx;
            startRot[idx] = transform.rotation;
            t = 0;

            startPos[idx] = transform.position;
        }


		//rb.position += -transform.up * s * Time.deltaTime;
		rb.MovePosition(rb.position + -transform.up * s * Time.deltaTime);

		if (maxIdx >= idx)
        {
			//transform.position = Vector3.Lerp(startPos[idx], endTransform[idx].position, t / maxT[idx]);
			transform.rotation = Quaternion.Slerp(startRot[idx], endTransform[idx].rotation, t / maxT[idx]);
        }
    }
}