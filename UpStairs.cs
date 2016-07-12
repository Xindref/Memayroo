using UnityEngine;
using System.Collections;

public class UpStairs : MonoBehaviour {

    public Transform warpTarget;

	void OnTriggerEnter (Collider other)
    {
        other.gameObject.transform.position = new Vector3 (warpTarget.position.x, 4.1f, warpTarget.position.z + 1);
    }
}
