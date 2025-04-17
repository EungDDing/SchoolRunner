using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public interface IScroll
{
    // scroll item
    public void Scroll();
    public void SetScrollSpeed(float newSpeed);
    public void SetEnableScroll(bool isEnable);
}
