using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AvalonClient {
   public class Players {
        private Queue<string> _inBuffer;
        
        public string Name { get; set; }
        public PlayingCards Card { get; set; }
        public bool IsKing { get; set; }
        public bool IsOnMissionTeam { get; set; }
        public bool IsLadyLake { get; set; }
        public bool TeamVote { get; set; } 
        public bool MissionVote { get; set; } 
        public States CurrentState { get; set; }
        public int Score { get; set; }
        public Socket socket { get; set; }
        public string InBuffer {
            get {
                if (_inBuffer.Count > 0) {
                    return _inBuffer.Dequeue();
                }

                return null;
            }
            set {
                if (value != null) {
                    string[] messages = value.Split('\n');
                    foreach (string msg in messages) {
                        _inBuffer.Enqueue(msg);
                    }
                }
            }
        }
        public string OutBuffer { get; set; } //not really using this, just leaving it so server code doesn't have to change
        public DateTime LastDisconnected { get; set; }
       
       public Players() {
            CurrentState = States.NONE;
            _inBuffer = new Queue<string>();
            IsOnMissionTeam = false;
            IsKing = false;
            IsLadyLake = false;
            Score = 0;
            Name = "Sir Dufus";
        }
    }

   public enum PlayingCards { MERLIN, PERCIVAL, SERVANT_OF_ARTHUR, MORDRED, MORGANA, OBERON, ASSASSIN, MINION_OF_MORDRED }; 
   public enum States { LOGGING_IN, CONNECTED, PLAYING, VOTING_TEAM, VOTING_MISSION, VOTING_MERLIN, PLAYING_LADYLAKE, LIMBO, DISCONNECT, NONE };
}
