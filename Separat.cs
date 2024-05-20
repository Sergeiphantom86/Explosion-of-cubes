using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Explosion), typeof(Color))]

public class Separat : MonoBehaviour
{
    private List<Rigidbody> _rigidbodysNewCubes = new();
    private const float _chanceSeparat = 1.0f;
    private GameObject _newCube;

    void Start()
    {
        gameObject.AddComponent<Color>().Replace();
    }

    private void OnMouseDown()
    {
        if (_chanceSeparat >= Random.value)
        {
            AddNewCubs();

            _newCube.AddComponent<Explosion>().UseExplosion(_rigidbodysNewCubes);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewCubs()
    {
        int minQuantity = 2;
        int maxQuantity = 6;

        int quantityItems = Random.Range(minQuantity, maxQuantity);

        for (int i = 0; i <= quantityItems; i++)
        {
            _newCube = СreateNewGameObject();

            ReduceSize();

            _rigidbodysNewCubes.Add(_newCube.GetComponent<Rigidbody>());
        }
    }

    private GameObject СreateNewGameObject()
    {
        return Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    private void ReduceSize()
    {
        int scaleItem = 2;

        _newCube.transform.localScale = transform.lossyScale / scaleItem;
    }
}
