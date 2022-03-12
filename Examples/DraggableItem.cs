using System.Collections;
using System.Collections.Generic;
using Tools.DragAndDrop;
using UnityEngine;

public class DraggableItem : Item
{
    Vector2 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    public override void OnItemDropped()
    {
        
    }
    public override void OnItemPicked()
    {
        
    }
    public void ResetPosition()
    {
        SetPosition(startPosition);
    }
}
