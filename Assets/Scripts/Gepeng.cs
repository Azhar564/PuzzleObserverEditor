using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gepeng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, pos.y, transform.position.z), Time.deltaTime);
    }
}
