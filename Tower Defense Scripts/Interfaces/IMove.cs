using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void GetDestination();
    void Move();
    void EndOfPath();
}
