using UnityEditor;
using UnityEngine;

public class JustForFun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Calling it just for fun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Handles.Label(Vector3.zero, "Whats going on man");
    }
}
