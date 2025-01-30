namespace TicTacToeTest;

using System;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.IO;


public class CursorTest {
    private Cursor cursor;

    [SetUp]
    public void Setup() {
        var keyToMoveMap = new KeyToMoveMap('i', 'k', 'j', 'l', 'q', ' ');
        cursor = new Cursor(3, keyToMoveMap);
        cursor.MoveDown();
        cursor.MoveRight();
    }

    [Test]
    public void CursorCenterTest() {
        Assert.True(cursor.position.X == 1 && cursor.position.Y == 1);
    }

    [Test]
    public void MoveUpTest() {
        cursor.MoveUp();
        Tuple<int, int> cursorMovedUp = Tuple.Create(cursor.position.X, cursor.position.Y);
        cursor.MoveUp();
        Assert.True(cursorMovedUp.Item1 == cursor.position.X
        && cursorMovedUp.Item2 == cursor.position.Y);
    }

    [Test]
    public void MoveDownTest() {
        cursor.MoveDown();
        Tuple<int, int> cursorMovedDown = Tuple.Create(cursor.position.X, cursor.position.Y);
        cursor.MoveDown();
        Assert.True(cursorMovedDown.Item1 == cursor.position.X
        && cursorMovedDown.Item2 == cursor.position.Y);
    }
    
    [Test]
    public void MoveLeftTest() {
        cursor.MoveLeft();
        Tuple<int, int> cursorMovedLeft = Tuple.Create(cursor.position.X, cursor.position.Y);
        cursor.MoveLeft();
        Assert.True(cursorMovedLeft.Item1 == cursor.position.X
        && cursorMovedLeft.Item2 == cursor.position.Y);
    }

    [Test]
    public void MoveRightTest() {
        cursor.MoveRight();
        Tuple<int, int> cursorMovedRight = Tuple.Create(cursor.position.X, cursor.position.Y);
        cursor.MoveRight();
        Assert.True(cursorMovedRight.Item1 == cursor.position.X
        && cursorMovedRight.Item2 == cursor.position.Y);
    }   
}
