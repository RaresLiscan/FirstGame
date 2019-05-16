using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    public Transform characterstart;
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        for (float i = characterstart.position.x + 30; i <= 1000; i += 30)
        {
            Instantiate(obstacle, new Vector3(i, characterstart.position.y, characterstart.position.z), characterstart.rotation);
        }
        for (float i = characterstart.position.x - 30; i >= -1000; i -= 30)
        {
            Instantiate(obstacle, new Vector3(i, characterstart.position.y, characterstart.position.z), characterstart.rotation);
        }
    }

}
