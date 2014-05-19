using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySockets;
namespace Avalon {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            ServerForm serverForm = new ServerForm();
            Server server = Server.GetServer(serverForm);
            Game game = new Game(serverForm, server);
            
            ThreadPool.QueueUserWorkItem(delegate { game.Run(); });
            serverForm.ShowDialog();           
        }
    }

    public class Game {
        private List<PlayingCards> _currentRoleDeck;

        private List<PlayingCards> CurrentRoleDeck {
            get {
                return _currentRoleDeck;
            }
            set {
                _currentRoleDeck = value;
            }
        }
        private Server Server {get; set;}
        private ServerForm ServerForm { get; set; }
        public List<Players> PlayersPlaying { get; set; }
        
        private int CurrentRound { get; set; }
        private int PlayersInGame {
            get {
                return PlayersPlaying.Count;
            }
        }
        private int Minions { get; set; }
        private int Servants { get; set; }
        private int Specials { get; set; }
        private int CurrentTeamSelectionRound { get; set; }
        private int MaxRounds { get; set; }
        private int MaxTeamMembersCurrentRound { get; set; }
        private int MissionsPassed { get; set; }
        private int MissionsFailed { get; set; }
        private bool CurrentMissionResult { get; set; }
        private int CurrentMissionFailsRequired { get; set; }
        private int CurrentKing { get; set; }
        private int CurrentLadyLake { get; set; }
        private int CurrentRoundApprove { get; set; }
        private int CurrentRoundReject { get; set; }
        private int CurrentMissionFails { get; set; }
        private bool MatchOver {get; set;}
        private const int MaxSelectionRounds = 5;
        private bool LadyOfTheLake { get; set; }
        private bool Merlin { get; set; }
        private bool Percival { get; set; }
        private bool Mordred { get; set; }
        private bool Morgana { get; set; }
        private bool Oberon { get; set; }
        private bool Assassin { get; set; }

        public Game(ServerForm serverForm, Server server) {
            ServerForm = serverForm;
            Server = server;
            CurrentRoleDeck = new List<PlayingCards>();
            CurrentKing = -1;
            CurrentLadyLake = -1;
            CurrentTeamSelectionRound = 1;
            CurrentRound = 1;
            MaxRounds = 5;
            MaxTeamMembersCurrentRound = 5;
            MatchOver = true;
        }

        public void Run() {
            while (ServerForm != null) {
                PlayersPlaying = new List<Players>();
                bool firstLoop = true;
                while (!ServerForm.StartGame) {
                    if (firstLoop) {
                        ServerForm.LogIt(">>>Game Stopped<<<");
                        firstLoop = false;
                    }
                    PlayersPlaying = Server.GetCurrentUserList();
                    Thread.Sleep(3000); //just sit and wait
                }

                ServerForm.LogIt(">>>Game Starting<<<");

                CheckPlayers();

                SetupGame();

                while (ServerForm.StartGame) {
                    if (MatchOver) {
                        EndMatch();
                        StartMatch();
                    }
                    StartRound();
                }

                EndMatch();
            }
        }

        private void CheckPlayers() {
            foreach (Players player in PlayersPlaying) {
                if (player.CurrentState == States.LOGGING_IN) {
                    this.Server.SendToClient(player.socket, "REQUEST_NAME\n");
                    ServerForm.LogIt("Requested name from " + player.socket.RemoteEndPoint);
                }
            }

            AwaitLoginResponses();
        }

        private void AwaitLoginResponses() {
            try {
                while (PlayersPlaying.Where(p => p.CurrentState == States.LOGGING_IN).Count() > 0 && ServerForm.StartGame) {
                    foreach (Players player in PlayersPlaying.Where(p => p.CurrentState == States.LOGGING_IN)) {
                        string response = player.InBuffer;
                        if (!string.IsNullOrEmpty(response) && response != "\0") {
                            player.Name = response;
                            player.CurrentState = States.PLAYING;
                            ServerForm.LogIt("Name received from " + response + " (" + player.socket.RemoteEndPoint + ")");
                        }
                    }
                    Thread.Sleep(3000);
                }
            }
            catch (Exception) { }
        }

        //needs to be finished
        public void SetupGame() {

            LadyOfTheLake = ((CheckBox)ServerForm.Controls["withLadyLake"]).Checked;
            if (((RadioButton)((GroupBox)ServerForm.Controls["groupBox1"]).Controls["nonCustomValue"]).Checked) {
                DetermineNumberOfMinionsAndServants();
            }
            else {
                Merlin = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withMerlin"]).Checked;
                Percival = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withPercival"]).Checked;
                Mordred = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withMordred"]).Checked;
                Morgana = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withMorgana"]).Checked;
                Oberon = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withOberon"]).Checked;
                Assassin = ((CheckBox)ServerForm.Controls["groupBox1"].Controls["withAssassin"]).Checked;
            }
        }

        private void IncreaseScores(string alignment) {
            List<PlayingCards> faction = new List<PlayingCards>();

            if (alignment == "GOOD") {
                faction.Add(PlayingCards.MERLIN);
                faction.Add(PlayingCards.PERCIVAL);
                faction.Add(PlayingCards.SERVANT_OF_ARTHUR);
            }
            else{
                faction.Add(PlayingCards.MORDRED);
                faction.Add(PlayingCards.MORGANA);
                faction.Add(PlayingCards.OBERON);
                faction.Add(PlayingCards.ASSASSIN);
                faction.Add(PlayingCards.MINION_OF_MORDRED);
            }

            foreach (Players player in PlayersPlaying.Where(p => faction.Contains(p.Card))) {
                player.Score++;
            }
        }

        private bool AssassinateMerlin() {
            Players assassin = PlayersPlaying.Where(p => p.Card == PlayingCards.ASSASSIN).SingleOrDefault();
            Server.SendToAllClients("FIND_MERLIN");
            Server.SendToClient(assassin.socket, "KILL_MERLIN");

            return AwaitAssassinateTargetResponse();

        }

        private bool AwaitAssassinateTargetResponse() {
            try {
                string response = "";
                Players assassin = PlayersPlaying.Where(p => p.Card == PlayingCards.ASSASSIN).SingleOrDefault();
                response = assassin.InBuffer;

                while (!string.IsNullOrEmpty(response) && response != "\0" && ServerForm.StartGame) {
                    response = assassin.InBuffer;
                    Thread.Sleep(3000);
                }

                PlayingCards target = PlayersPlaying.Where(p => p.Name == response).Single().Card;
                if (target == PlayingCards.MERLIN) {
                    return true;
                }
            }
            catch (Exception) { }

            return false;
        }

        //things that are done at the beginning of every match
        private void StartMatch() {
            Server.SendToAllClients("RESET_MATCH\n");
            DisseminatePlayerList();
            MatchOver = false;
            CurrentMissionFails = 0;
            CurrentRound = 1;
            CurrentTeamSelectionRound = 1;

            DetermineNumberOfMinionsAndServants();
            ShuffleCards();
            HandOutCardsToPlayers();
        }

        private void StartRound() {
            ServerForm.LogIt("Starting round " + CurrentRound);
            CalculatePlayersPerRoundForMissions();
            DetermineKing();
            ServerForm.LogIt("Waiting 10 seconds");
            Thread.Sleep(10000);
            PickTeam();
            Thread.Sleep(10000);

            if (DetermineTeamVoteOutcome() && DetermineMatchContinues()) {
                CurrentTeamSelectionRound = 1;
                Server.SendToAllClients("RESET_TEAM_SELECTION_ROUND\n");
                ServerForm.LogIt("Waiting 10 seconds");
                Thread.Sleep(10000);
                MissionVote();
                EndRound(true);
            }
            else {
                EndRound();
            }

            ServerForm.LogIt("Waiting 10 seconds");
            Thread.Sleep(10000);
        }

        private void EndRound(bool voted = false) {
            if (voted) {
                if (CurrentMissionResult) {
                    MissionsFailed++;
                }
                else {
                    MissionsPassed++;
                }

                Server.SendToAllClients("MISSION_VOTE_FAILS " + CurrentMissionFails + ";" + CurrentMissionFailsRequired + "\n");

                if (MissionsPassed == 3) {
                    Server.SendToAllClients("GOOD_WIN\n");
                    MatchOver = true;

                    if (Merlin && Assassin) {
                        if (AssassinateMerlin()) {
                            Server.SendToAllClients("MERLIN_KILLED True\n");
                            //it's a tie (house rules) no points awarded to Gryffindor
                        }
                        else {
                            Server.SendToAllClients("MERLIN_KILLED False\n");
                            IncreaseScores("GOOD");
                        }
                    }
                    else {
                        IncreaseScores("GOOD");
                    }
                }
                else if (MissionsFailed == 3) {
                    MatchOver = true;
                    Server.SendToAllClients("EVIL_WIN\n");
                    IncreaseScores("EVIL");
                }

                CurrentRound++;
            }

            if (CurrentTeamSelectionRound > MaxSelectionRounds) {
                MatchOver = true;
                Server.SendToAllClients("EVIL_WIN\n");
                IncreaseScores("EVIL");
            }

            ServerForm.LogIt("Round Ended");
            
           
            CurrentRoundApprove = 0;
            CurrentRoundReject = 0;
            CurrentMissionFails = 0;
        }

        private void MissionVote() {
            ServerForm.LogIt("Informing players on team to submit mission votes");
            foreach (Players player in PlayersPlaying.Where(p => p.IsOnMissionTeam == true)) {
                Server.SendToClient(player.socket, "VOTE_MISSION\n");
            }

            AwaitMissionVotes();
        }

        private void AwaitMissionVotes() {
            ServerForm.LogIt("Awaiting votes for mission");
            int totalVotes = 0;
            int votesNeeded = PlayersPlaying.Where(p => p.IsOnMissionTeam == true).Count();

            try {
                while (totalVotes != votesNeeded && ServerForm.StartGame) {
                    foreach (Players player in PlayersPlaying.Where(p => p.IsOnMissionTeam == true && p.CurrentState == States.PLAYING)) {
                        string vote = player.InBuffer.Replace("\0","");
                        if (!string.IsNullOrEmpty(vote) && vote != "\0") {
                            totalVotes++;
                            player.MissionVote = bool.Parse(vote);
                            player.IsOnMissionTeam = false;
                            ServerForm.LogIt("Vote received from " + player.Name);
                            if (!player.MissionVote) {
                                CurrentMissionFails++;
                            }
                        }
                    }
                    Thread.Sleep(3000);
                    //we went through once, let's update our player list in case of disconnects
                    //PlayersPlaying = Server.GetCurrentUserList();
                }
            }
            catch (Exception) { }

            CurrentMissionResult = CurrentMissionFails >= CurrentMissionFailsRequired;
        }

        private void EndMatch() {
            string scores = "SCORES ";
            string reveals = "REVEAL ";
            foreach (Players player in PlayersPlaying) {
                scores += player.Name + " " + player.Score + ";";
                reveals += player.Name + " " + player.Card.ToString() + ";";
            }

            Server.SendToAllClients(scores + "\n");
            Server.SendToAllClients(reveals + "\n");

            ServerForm.LogIt("Match Ended");
            MissionsFailed = 0;
            MissionsPassed = 0;
            CurrentTeamSelectionRound = 1;
            
        }

        private bool DetermineTeamVoteOutcome() {
            bool voteRequired = false;
            if (CurrentRoundReject >= CurrentRoundApprove) {
                CurrentTeamSelectionRound++;
               
                Server.SendToAllClients("TEAM_REJECTED\n");
            }
            else {
                Server.SendToAllClients("TEAM_APPROVED\n");
                voteRequired = true;
            }

            Thread.Sleep(10000);
            return voteRequired;
        }

        private bool DetermineMatchContinues() {
            bool result = false;

            if (CurrentTeamSelectionRound < MaxRounds) {
                result = true;
            }

            if (MissionsPassed + MissionsFailed < MaxRounds) {
                result = true;
            }

            return result;
        }

        private void PickTeam() {
            Server.SendToClient(PlayersPlaying[CurrentKing].socket, "CHOOSE_TEAM " + MaxTeamMembersCurrentRound + "\n");
            ServerForm.LogIt(PlayersPlaying[CurrentKing].Name + " is picking team to go on mission");
            AwaitTeamResponse();
        }

        private void AwaitTeamResponse() {
            ServerForm.LogIt("Awaiting team member names");
            string response = PlayersPlaying[CurrentKing].InBuffer.Replace("\0","");
            try {
                while (string.IsNullOrEmpty(response) && ServerForm.StartGame) {
                    response = PlayersPlaying[CurrentKing].InBuffer;
                    response = response.Replace("\0", "");
                    Thread.Sleep(3000);
                    //PlayersPlaying = Server.GetCurrentUserList();
                }
            }
            catch (Exception) { }

            if (string.IsNullOrEmpty(response)) {
                response = "";
            }

            ServerForm.LogIt("Team member names received: " + response.Replace("TEAM ",""));
            string[] namesForTeam = response.Replace("TEAM ", "").Split(';');
            foreach (Players player in PlayersPlaying) {
                if (namesForTeam.Contains(player.Name)){
                    player.IsOnMissionTeam = true;
                }
            }
            //ok team has been selected lets inform everyone
            Server.SendToAllClients("TEAM_VOTE " + response.Replace("TEAM ","") + "\n");
            ServerForm.LogIt("Clients instructed to vote for team approval");
            AwaitTeamVoteResponse();
        }

        private void AwaitTeamVoteResponse() {
            ServerForm.LogIt("Awaiting player votes for team approval for round " + CurrentRound);
            CurrentRoundApprove = 0;
            CurrentRoundReject = 0;
            try {
                while (CurrentRoundApprove + CurrentRoundReject != PlayersInGame && ServerForm.StartGame) {
                    foreach (Players player in PlayersPlaying.Where(p => p.CurrentState == States.PLAYING)) {
                        string vote = player.InBuffer.Replace("\0","");
                        if (!string.IsNullOrEmpty(vote) && vote != "\0") {
                            player.TeamVote = bool.Parse(vote);
                            if (player.TeamVote) {
                                CurrentRoundApprove++;
                            }
                            else {
                                CurrentRoundReject++;
                            }
                        }
                    }
                    Thread.Sleep(3000);
                    //PlayersPlaying = Server.GetCurrentUserList();
                }
            }
            catch (Exception) { }

            ServerForm.LogIt("All votes received");

            Server.SendToAllClients(CreateTeamVoteString());
            ServerForm.LogIt("All clients notified of result");
        }

        private string CreateTeamVoteString() {
            string result = "TEAM_VOTE_RESULTS ";
            foreach (Players player in PlayersPlaying) {
                result += player.Name + " " + player.TeamVote + ";";
            }

            return result + "\n";
        }

        private void DetermineLadyLake() {
            if (LadyOfTheLake) {
                CurrentLadyLake = CurrentKing - 1;
                Server.SendToAllClients("LADY_OF_THE_LAKE " + PlayersPlaying[CurrentLadyLake].Name + "\n"); 
            }
             
        }

        private void DetermineKing() {
            if (CurrentKing == -1) {
                CurrentKing = new Random().Next(0, PlayersInGame);
            }
            else {
                CurrentKing++;
                if (CurrentKing == PlayersPlaying.Count) {
                    CurrentKing = 0;
                }
            }

            Server.SendToAllClients("KING " + PlayersPlaying[CurrentKing].Name + "\n");

            DetermineLadyLake();
        }
    

        private void DisseminatePlayerList() {
            string message = "PLAYERS_IN_GAME ";
            foreach (Players player in PlayersPlaying) {
                message += player.Name + ";";
            }

            Server.SendToAllClients(message + "\n");
            ServerForm.LogIt("Players list sent to all clients");
        }

        private void HandOutCardsToPlayers() {
            string roles = "ROLES ";
            int index = 0;
            PlayersPlaying = Server.GetCurrentUserList();
            if (ServerForm.StartGame) {
                foreach (Players player in PlayersPlaying) {
                    player.Card = CurrentRoleDeck[index];
                    roles += player.Name + " " + player.Card.ToString() + ";";
                    Server.SendToClient(player.socket, player.Card.ToString() + "\n");
                    index++;
                    ServerForm.LogIt(player.Name + " assigned role");
                }

                Server.SendToAllClients(roles + "\n");
            }
        }

        private void ShuffleCards() {
            CurrentRoleDeck.Clear();
            List<PlayingCards> tempDeck = AddGoodToDeck();                     
            tempDeck.AddRange(AddEvilToDeck());          

            List<int> pickedNumbers = new List<int>();

            Random rand = new Random();
            int nextRandom = rand.Next(0, tempDeck.Count);

            while (CurrentRoleDeck.Count != PlayersInGame && ServerForm.StartGame) {
                if (!pickedNumbers.Contains(nextRandom)){
                    CurrentRoleDeck.Add(tempDeck[nextRandom]);
                    pickedNumbers.Add(nextRandom);
                }
                
                nextRandom = rand.Next(0, tempDeck.Count);
            }

            if (CurrentRoleDeck.Count == 0) {
                CurrentRoleDeck.Add(tempDeck[0]);
            }

            ServerForm.LogIt("Cards shuffled");
        }

        private List<PlayingCards> AddGoodToDeck() {
            List<PlayingCards> result = new List<PlayingCards>();
            if (Merlin) {
                result.Add(PlayingCards.MERLIN);
            }
            if (Percival) {
                result.Add(PlayingCards.PERCIVAL);
            }

            int remainingGood = result.Count;
            for (int i = 0; i < Servants - remainingGood; i++) {
                result.Add(PlayingCards.SERVANT_OF_ARTHUR);
            }
            
            return result;
        }

        private List<PlayingCards> AddEvilToDeck() {
            List<PlayingCards> result = new List<PlayingCards>();
            if (Mordred) {
                result.Add(PlayingCards.MORDRED);
            }
            if (Morgana) {
                result.Add(PlayingCards.MORGANA);
            }
            if (Oberon) {
                result.Add(PlayingCards.OBERON);
            }
            if (Assassin) {
                result.Add(PlayingCards.ASSASSIN);
            }

            int remainingEvil = result.Count;
            for (int i = 0; i < Minions - remainingEvil; i++) {
                result.Add(PlayingCards.MINION_OF_MORDRED);
            }
            
            return result;
        }

        private void CalculatePlayersPerRoundForMissions() {
            switch (CurrentRound) {
                case 1:
                    CurrentMissionFailsRequired = 1;
                    switch (PlayersInGame) {
                        case 5:
                        case 6:
                        case 7:
                            MaxTeamMembersCurrentRound = 2;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            MaxTeamMembersCurrentRound = 3;
                            break;
                        default:
                            MaxTeamMembersCurrentRound = 1;
                            break;
                    }
                    break;
                case 2:
                    CurrentMissionFailsRequired = 1;
                    switch (PlayersInGame) {
                        case 5:
                        case 6:
                        case 7:
                            MaxTeamMembersCurrentRound = 3;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            MaxTeamMembersCurrentRound = 4;
                            break;
                        default:
                            MaxTeamMembersCurrentRound = 1;
                            break;
                    }
                    break;
                case 3:
                    CurrentMissionFailsRequired = 1;
                    switch (PlayersInGame) {
                        case 5:
                            MaxTeamMembersCurrentRound = 2;
                            break;
                        case 6:
                            MaxTeamMembersCurrentRound = 4;
                            break;
                        case 7:
                            MaxTeamMembersCurrentRound = 3;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            MaxTeamMembersCurrentRound = 4;
                            break;
                        default:
                            MaxTeamMembersCurrentRound = 1;
                            break;
                    }
                    break;
                case 4:
                    CurrentMissionFailsRequired = 2;
                    switch (PlayersInGame) {
                        case 5:
                        case 6:
                            CurrentMissionFailsRequired = 1;
                            MaxTeamMembersCurrentRound = 3;
                            break;
                        case 7:
                            MaxTeamMembersCurrentRound = 4;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            MaxTeamMembersCurrentRound = 5;
                            break;
                        default:
                            MaxTeamMembersCurrentRound = 1;
                            break;
                    }
                    break;
                case 5:
                    CurrentMissionFailsRequired = 1;
                    switch (PlayersInGame) {
                        case 5:
                            MaxTeamMembersCurrentRound = 3;
                            break;
                        case 6:
                        case 7:
                            MaxTeamMembersCurrentRound = 4;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            MaxTeamMembersCurrentRound = 5;
                            break;
                        default:
                            MaxTeamMembersCurrentRound = 1;
                            break;
                    }
                    break;
                default:
                    CurrentMissionFailsRequired = 1;
                    MaxTeamMembersCurrentRound = 2;
                    break;
            }
        }

        private void DetermineNumberOfMinionsAndServants() {
            Merlin = Percival = Mordred = Morgana = Oberon = Assassin = true;
            switch (PlayersInGame) {
                case 5:
                    Merlin = Percival = Morgana = Oberon = Mordred = Assassin = false;
                    Minions = 2;
                    Servants = 3;
                    break;
                case 6:
                    Merlin = Percival = Morgana = Oberon = Mordred = Assassin = false;
                    Minions = 2;
                    Servants = 4;
                    break;
                case 7:
                    Percival = Morgana = Oberon = false;
                    Minions = 3;
                    Servants = 4;
                    break;
                case 8:
                    Percival = Morgana = Oberon = false;
                    Minions = 3;
                    Servants = 5;
                    break;
                case 9:
                    Percival = Morgana = Oberon = false;
                    Minions = 3;
                    Servants = 6;
                    break;
                case 10:
                    Minions = 4;
                    Servants = 6;
                    break;
                default:
                    Merlin = Percival = Morgana = Oberon = Mordred = Assassin = false;
                    Minions = 1;
                    Servants = 1;
                    break;
            }
        }
    }

   
}
