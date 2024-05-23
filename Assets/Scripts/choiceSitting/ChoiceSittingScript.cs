using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSittingScript : MonoBehaviour
{
    public GameObject friendDetailPrefab;
    private GameObject _object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        _object = Instantiate(friendDetailPrefab, transform);
    }

    public void OnPointerExit()
    {
        Destroy(_object);
    }

}
