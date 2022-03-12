using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Tools.DragAndDrop
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public abstract class Item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField, HideInInspector]
        Collider2D collider2d;
        [SerializeField, HideInInspector]
        Rigidbody2D rigidbody2d;
        public UnityEvent<Item> onItemDropped;
        public UnityEvent<Item> onItemPicked;

        Vector2 offset;
        Vector2 mousePosition
        {
            get
            {
                Vector2 pointerPosition = Mouse.current.position.ReadValue();
                return Camera.main.ScreenToWorldPoint(pointerPosition);
            }
        }
        public bool isDragging
        {
            get;
            private set;
        }
        void OnValidate()
        {
            collider2d = GetComponent<Collider2D>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            collider2d.isTrigger = true;
            rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
        }
        void Update()
        {
            if (isDragging)
            {
                transform.position = mousePosition + offset;
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            offset = (Vector2)transform.position - mousePosition;
            isDragging = true;
            onItemPicked.Invoke(this);
            OnItemPicked();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            Drop();
        }
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
        public abstract void OnItemPicked();
        public abstract void OnItemDropped();
        public void Drop()
        {
            isDragging = false;
            onItemDropped.Invoke(this);
            OnItemDropped();
        }
    }
}

