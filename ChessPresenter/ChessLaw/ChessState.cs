using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public enum ChessType { None, Pawn, Knight, Bishop, Rook, Queen, King };
    public class ChessState
    {
        public List<List<ChessType>> State { get; set; }
    }
}
