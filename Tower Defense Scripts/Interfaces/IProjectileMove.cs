﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileMove
{
    void Move();
    void Move(Vector2 direction);
}
