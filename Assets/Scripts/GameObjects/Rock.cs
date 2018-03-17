using Completed;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MovingObject {

    internal void MoveRock(int xDir, int yDir)
    {
        RaycastHit2D hit;
        Move(xDir,yDir, out hit);
    }

    protected override void ChangeLeverState(GameObject lever)
    {
        throw new NotImplementedException();
    }

    protected override void MoveRock(GameObject rock, int xDir, int yDir)
    {
        throw new NotImplementedException();
    }

    protected override void OnCantMove<T>(T component)
    {
        throw new NotImplementedException();
    }
}
