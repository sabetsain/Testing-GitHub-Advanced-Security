namespace TicTacToe;

using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Interfaces;


/// <summary>
/// A basic board checker that will determine if for a given row, diagonal or column, if all of
/// the elements is equal to eachother and not equal to null. It will also determine if the board
/// is in a tied position.
/// </summary>
public class BoardChecker : IBoardChecker {

    /// <summary>
    /// Method that is used to check if all elements in a row is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the row is equal else false.
    /// </returns>
    private bool IsRowWin(Board board) {
        for (int i = 0; i < board.Size; i++) {
            bool gameWon = true;
            PlayerIdentifier? firstValue = null;

            for (int j = 0; j < board.Size; j++) {
                PlayerIdentifier? currentValue = board.Get(j, i);

                if (!currentValue.HasValue || firstValue.HasValue && currentValue != firstValue) {
                    gameWon = false;
                    break;
                } else if (!firstValue.HasValue) {
                    firstValue = currentValue;
                } 
            } if (gameWon) {
                return true;
            }
        } return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a column is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the column is equal else false.
    /// </returns>
    private bool IsColWin(Board board) {
        for (int i = 0; i < board.Size; i++) {
            bool gameWon = true;
            PlayerIdentifier? firstValue = null;

            for (int j = 0; j < board.Size; j++) {
                PlayerIdentifier? currentValue = board.Get(i, j);

                if (!currentValue.HasValue || firstValue.HasValue && currentValue != firstValue) {
                    gameWon = false;
                    break;
                } else if (!firstValue.HasValue) {
                    firstValue = currentValue;
                } 
            } if (gameWon) {
                return true;
            }
        } return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a diagonal is equal to eachother and is not
    /// equal to null. This diagonal will always be the two longest in a square.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the diagonal is equal else false.
    /// </returns>
    private bool IsDiagWin(Board board) {
        List<PlayerIdentifier?> leftDownDiagonal = new List<PlayerIdentifier?>();
        List<PlayerIdentifier?> rightDownDiagonal = new List<PlayerIdentifier?>();

        for (int i = 0; i < board.Size; i++) {
            leftDownDiagonal.Add(board.Get(i, i));
            rightDownDiagonal.Add(board.Get(board.Size - i - 1, i));
        }

        if (leftDownDiagonal.All(objects => objects == leftDownDiagonal.First())
        && leftDownDiagonal.First() != null
        || rightDownDiagonal.All(objects => objects == rightDownDiagonal.First())
        && rightDownDiagonal.First() != null) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Method that will determine what the state of the board is. If there is a winner, a tied or
    /// the game is still inconclusive.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns> The state of the board.</returns>
    public BoardState CheckBoardState(Board board) {
        if (board.IsFull()) {
            return BoardState.Tied;
        } else if (IsDiagWin(board) || IsColWin(board) || IsRowWin(board)) {
            return BoardState.Winner;
        } else {
            return BoardState.Inconclusive;
        }
        // throw new NotImplementedException();
    }
}