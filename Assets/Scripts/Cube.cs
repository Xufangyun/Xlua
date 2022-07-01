using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


[Hotfix]
public class Cube : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    [LuaCallCSharp]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.up * 500);
        }
    }
}
