using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAttributeController
{
    event Action<int> onValueChange;
    void Initialize(int value);
    void Increase(int value);
    void Decrease(int value);
}
