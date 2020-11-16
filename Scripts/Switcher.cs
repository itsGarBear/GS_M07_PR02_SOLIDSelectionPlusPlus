using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> changeableObjs;
    private List<IChangeable> changeables = new List<IChangeable>();

    private void Start()
    {
        for(int i = 0; i < changeableObjs.Count; i++)
        {
            var chngObj = changeableObjs[i].GetComponent<IChangeable>();
            changeables.Add(chngObj);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            for(int i = 0; i < changeables.Count; i++)
            {
                changeables[i].Next();
            }
        }
    }
}

public interface IChangeable
{
    void Next();
}