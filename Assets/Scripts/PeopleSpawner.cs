using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleSpawner : MonoBehaviour
{
    public static int numOfPeopleToSpawn = 8;
    public GameObject person;
    public GameObject uiPeopleToPass;

    private GameObject[] people = new GameObject[numOfPeopleToSpawn];
    private int personId = 0;
    BoxCollider2D startCollider;

    void Start()
    {
        //TODO: uiPeopleToPass.GetComponent<>
        startCollider = GameObject.FindGameObjectWithTag("Start").GetComponent<BoxCollider2D>();
        for (int i=0; i<numOfPeopleToSpawn; i++)
        {
            people[i] = person;
            GameObject.Instantiate(people[i]);
            people[i].SetActive(true);
        }

        StartCoroutine(ActivatePeople(1.0f));
    }

    IEnumerator ActivatePeople(float i_startTime)
    {
        people[personId].SetActive(true);
        if(numOfPeopleToSpawn < 7)
        {
            personId++;
            StartCoroutine(ActivatePeople(Random.Range(1.0f, 4.0f)));
        }

        yield return new WaitForSeconds(i_startTime);
    }
}
