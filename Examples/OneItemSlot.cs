using System.Collections;
using System.Collections.Generic;
using Tools.DragAndDrop;
using UnityEngine;

public class OneItemSlot : Slot
{
    DraggableItem item;
    protected override void OnItemDropped(Item item)
    {
        if (this.item == null)
        {
            item.SetPosition(transform.position);
            this.item = (DraggableItem)item;
        }
        else if (this.item != item)
        {
            ((DraggableItem)item).ResetPosition();
        }
    }
    protected override void OnItemPicked(Item item)
    {
        if (item == this.item)
        {
            this.item = null;
        }
    }
}
