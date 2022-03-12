using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.DragAndDrop
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Slot : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        Collider2D collider2d;
        void OnValidate()
        {
            collider2d = GetComponent<Collider2D>();
            collider2d.isTrigger = true;
        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            Item item = collider.gameObject.GetComponent<Item>();
            if (item != null)
            {
                item.onItemDropped.AddListener(OnItemDropped);
                item.onItemPicked.AddListener(OnItemPicked);
            }
        }
        protected abstract void OnItemDropped(Item item);
        protected abstract void OnItemPicked(Item item);
        void OnTriggerExit2D(Collider2D collider)
        {
            Item item = collider.gameObject.GetComponent<Item>();
            if (item != null)
            {
                item.onItemDropped.RemoveListener(OnItemDropped);
                item.onItemPicked.RemoveListener(OnItemPicked);
            }
        }
    }
}

