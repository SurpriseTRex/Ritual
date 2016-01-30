using UnityEngine;
using System.Collections.Generic;

public class ToolItem : MonoBehaviour 
{
    public enum ItemType
    {
        Weapon,
        Container,
        Decorative
    }

    public ItemType type;

    public bool InteractWith(TargetItem target)
    {
        switch (type)
        {
            case ItemType.Weapon:
                Sacrifice s = target.gameObject.GetComponent<Sacrifice>();
                if (s)
                {
                    s.Kill();
                }
                break;
            case ItemType.Container:
                Liquid l = target.gameObject.GetComponent<Liquid>();
                if (l)
                {
                    l.Collect();
                }
                break;
            case ItemType.Decorative:
                DecorationSpace d = target.gameObject.GetComponent<DecorationSpace>();
                if (d)
                {
                    d.Decorate();
                }
                break;
        }

        return false;
    }
}