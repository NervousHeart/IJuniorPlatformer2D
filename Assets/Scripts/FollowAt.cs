using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAt : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        gameObject.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);
    }
}
