using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    public static int numOfPeopleToSpawn = 8;
    public GameObject person;

    private GameObject[] people = new GameObject[numOfPeopleToSpawn];

    void Start()
    {
        for(int i=0; i<numOfPeopleToSpawn; i++)
        {
            people[i] = person;
            GameObject.Instantiate(person);
            person.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
