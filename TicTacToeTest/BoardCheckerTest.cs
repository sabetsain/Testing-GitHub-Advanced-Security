namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;

public class BoardCheckerTest {

    public Board board;
    public BoardChecker boardChecker;

    [SetUp]
    public void Setup() {
        board = new Board(3);
        boardChecker = new BoardChecker();
    }

    [Test]
    public void DiagonalWinTest1() {
        board.TryInsert(2, 0, PlayerIdentifier.Naught);
        board.TryInsert(1, 1, PlayerIdentifier.Naught);
        board.TryInsert(0, 2, PlayerIdentifier.Naught);
        BoardState DiagWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(DiagWin, BoardState.Winner);
    }

    [Test]
    public void DiagonalWinTest2() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(1, 1, PlayerIdentifier.Naught);
        board.TryInsert(2, 2, PlayerIdentifier.Naught);
        BoardState DiagWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(DiagWin, BoardState.Winner);
    }

    [Test]
    public void RowWinTest1() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(1, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 0, PlayerIdentifier.Naught);
        BoardState RowWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(RowWin, BoardState.Winner);
    }

    [Test]
    public void RowWinTest2() {
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);
        BoardState RowWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(RowWin, BoardState.Winner);
    }
    
    [Test]
    public void ColumnWinTest1() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(0, 1, PlayerIdentifier.Naught);
        board.TryInsert(0, 2, PlayerIdentifier.Naught);
        BoardState ColWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(ColWin, BoardState.Winner);
    }

    public void ColumnWinTest2() {
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        board.TryInsert(2, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);
        BoardState ColWin = boardChecker.CheckBoardState(board);
        Assert.AreEqual(ColWin, BoardState.Winner);
    }

    [Test]
    public void InconclusiveTes1t() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        BoardState InconTest = boardChecker.CheckBoardState(board);
        Assert.AreEqual(InconTest, BoardState.Inconclusive);
    }

    [Test]
    public void InconclusiveTest2() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        board.TryInsert(2, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Naught);
        BoardState InconTest = boardChecker.CheckBoardState(board);
        Assert.AreEqual(InconTest, BoardState.Inconclusive);
    }

    [Test]
    public void InconclusiveTest3() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        board.TryInsert(1, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Naught);
        board.TryInsert(1, 2, PlayerIdentifier.Naught);
        board.TryInsert(2, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 1, PlayerIdentifier.Cross);
        BoardState InconTest = boardChecker.CheckBoardState(board);
        Assert.AreEqual(InconTest, BoardState.Inconclusive);
    }

    [Test]
    public void TiedTest() {
        board.TryInsert(0, 0, PlayerIdentifier.Naught);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(0, 2, PlayerIdentifier.Naught);
        board.TryInsert(1, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Naught);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        board.TryInsert(2, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);
        BoardState TieTest = boardChecker.CheckBoardState(board);
        Assert.AreEqual(TieTest, BoardState.Tied);
    }
}
