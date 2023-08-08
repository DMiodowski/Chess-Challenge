using ChessChallenge.API;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

public class MyBot : IChessBot
{
    const int pawnValue = 100;
    const int knightValue = 300;
    const int bishopValue = 300;
    const int rookValue = 500;
    const int queenValue = 900;
    public Move Think(Board board, Timer timer)
    {
        int whiteEval = 
        Move[] moves = board.GetLegalMoves();
        return moves[0];
    }

    public static int Evaluate()
    {
        int whiteEval = CountMaterial(Board.WhiteIndex);
        int blackEval = CountMaterial(Board.BlackIndex);
        int evaluation = whiteEval - blackEval;
        int perspective = (Board.WhiteToMove) ? 1 : -1;
        return evaluation * perspective;
    }

    static int CountMaterial(int colourIndex)
    {
        int material = 0;
        material += Board.pawns[colourIndex].Count * pawnValue;
        material += Board.knights[colourIndex].Count * knightValue;
        material += Board.bishops[colourIndex].Count * bishopValue;
        material += Board.rooks[colourIndex].Count * rookValue;
        material += Board.queens[colourIndex].Count * queenValue;
        return material;
    }
    int search (int depth, int alpha, int beta)
    {
        if (depth == 0) return Evaluate();
    
        List<Move> moves = MoveGenerator.GenerateMoves();
        if (moves.Count == 0)
        {
            if (Board.PlayerInCheck())
            {
                return negativeInfinity;
            }
            return 0;
        }
        int bestEvaluation = negativeInfinity;
        foreach( Move move in moves)
        {
            Board.MakeMove(move);
            int evaluation = - search(depth - 1, -beta,-alpha);
            Board.UnmakeMove(move);
            if (evaluation >= beta)
            {
                return beta;
            }
            alpha = Max(alpha, evaluation);
        }
        return alpha;
    }
    public void OrderMoves(List<Move> moves) { 
       foreach (Move move in moves)
        {
            int moveScoreGuess = 0;
            int movePieceType=Piece.PieceType (Board.Square)
        }
    }
}