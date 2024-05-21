using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Explosion), typeof(Probability), typeof(Color))]

public class Separat : MonoBehaviour
{
    private List<Rigidbody> _rigidbodysNewItem = new();

    private int _reductionFactor = 2;
    private float _chans;

    private void Start()
    {
        gameObject.AddComponent<Color>().Replace();

        _chans = gameObject.AddComponent<Probability>().GetSplitChance();
    }

    private void OnMouseDown()
    {
        if (_chans >= Random.value)
        {
            AddNewItem();

            gameObject.AddComponent<Explosion>().UseExplosion(_rigidbodysNewItem);

            gameObject.AddComponent<Probability>().SetSplitChance(_chans / _reductionFactor);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        int minQuantity = 2;
        int maxQuantity = 6;

        int quantityItems = Random.Range(minQuantity, maxQuantity);

        for (int i = 0; i <= quantityItems; i++)
        {
            ReduceSize(СreateNewGameObject());

            _rigidbodysNewItem.Add(gameObject.GetComponent<Rigidbody>());
        }
    }

    private GameObject СreateNewGameObject()
    {
        return Instantiate(gameObject, transform.position, Random.rotationUniform);
    }

    private void ReduceSize(GameObject newItem)
    {
        int scaleItem = 2;

        newItem.transform.localScale = transform.lossyScale / scaleItem;
    }
}