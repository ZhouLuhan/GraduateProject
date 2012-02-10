using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChessLaw;

namespace BasicWCFClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAIService" in both code and config file together.
    [ServiceContract]
    public interface IChessAIService
    {
        [OperationContract]
        void GameStart();
        [OperationContract]
        string GetStrategy(ChessState state, Boolean isWhite);
        [OperationContract]
        void UpdateResult(Boolean isWin);
    }
}
