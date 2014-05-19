using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySockets;
using System.Threading;

namespace AvalonClient {
    public partial class ClientForm : Form {
  
        private ClientTCP _tcpClient;
        private int CurrentTeamSelectionRound { get; set; }
        private int CurrentRound { get; set; }
        private bool Connected { get; set; }
        private List<string> PlayersOnTeam { get; set; }
        private static object LockMe { get; set; }
        private ClientTCP TcpClient {
            get {
                return _tcpClient;
            }
            set {
                _tcpClient = value;
            }
        }
        private Players Player { get; set; }
        private List<Players> PlayersPlaying { get; set; }
        private int MaxPlayersInTeam { get; set; }
        private int FailedVotesInRound { get; set; }
        private Bitmap RolePicture { get; set; }
        private int NeededFailVotes { get; set; }
        private bool MerlinKilled { get; set; }
        
        public ClientForm() {
            InitializeComponent();
            Player = new Players();
            LockMe = new Object();
            
            RolePicture = global::AvalonClient.Properties.Resources.Uknown;
            
            List<Bitmap> background = new List<Bitmap>();
            background.Add(global::AvalonClient.Properties.Resources.BackDrop);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop2);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop3);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop4);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop5);
            roundsPanel.BackgroundImage = background[new Random().Next(0, background.Count)];

            PlayersPlaying = new List<Players>();

            Task.Factory.StartNew(delegate { ConnectionStatus(); });
        }

        private void ConnectionStatus() {
            while (true) {
                try {
                    if (TcpClient != null && TcpClient.Connected) {
                        this.Invoke((MethodInvoker)delegate {
                            statusValue.Text = "Connected";
                            statusValue.ForeColor = System.Drawing.Color.Green;
                            ipValue.Enabled = portValue.Enabled = nameValue.Enabled = false;
                        });
                    }
                    else {
                        this.Invoke((MethodInvoker)delegate {
                            statusValue.Text = "Disconnected";
                            statusValue.ForeColor = System.Drawing.Color.Red;
                            ipValue.Enabled = portValue.Enabled = nameValue.Enabled = true;
                        });
                    }
                }
                catch (Exception) {
                }
                Thread.Sleep(5000);
            }
        }


        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(ipValue.Text) && string.IsNullOrEmpty(portValue.Text) || (nameValue.Text == "Sir Lies A Lot" || string.IsNullOrEmpty(nameValue.Text))) {
                MessageBox.Show("You need to provide a valid IP Address and port number\nfor the server as well as a proper name to identify you.", "No Server Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                try {
                System.Net.IPAddress.Parse(ipValue.Text);
                int.Parse(portValue.Text);
                
                    if (TcpClient == null || !TcpClient.Connected) {
                        TcpClient = new ClientTCP(ipValue.Text, int.Parse(portValue.Text));
                        TcpClient.DataReceived += OnDataReceived;
                    }
                }
                catch (Exception ex) {
                    ex.Message.ToString();
                }
            }
        }

        private void PerformServerRequest(ServerRequest request) {
            //a long laundry list
            switch (request) {
                case ServerRequest.MERLIN:
                case ServerRequest.PERCIVAL:
                case ServerRequest.MORDRED:
                case ServerRequest.MORGANA:
                case ServerRequest.ASSASSIN:
                case ServerRequest.OBERON:
                case ServerRequest.SERVANT_OF_ARTHUR:
                case ServerRequest.MINION_OF_MORDRED:
                    lock (LockMe) {
                        Player.Card = (PlayingCards)Enum.Parse(typeof(PlayingCards), request.ToString());
                        this.Invoke((MethodInvoker)delegate {
                            cardValue.Text = Player.Card.ToString();
                            switch (Player.Card) {
                                case PlayingCards.MERLIN:
                                    RolePicture = global::AvalonClient.Properties.Resources.Merlin;
                                    break;
                                case PlayingCards.MORDRED:
                                    RolePicture = global::AvalonClient.Properties.Resources.Mordred;
                                    break;
                                case PlayingCards.MORGANA:
                                    RolePicture = global::AvalonClient.Properties.Resources.Morgana;
                                    break;
                                case PlayingCards.OBERON:
                                    RolePicture = global::AvalonClient.Properties.Resources.Oberon;
                                    break;
                                case PlayingCards.ASSASSIN:
                                    RolePicture = global::AvalonClient.Properties.Resources.Assassin;
                                    break;
                                case PlayingCards.PERCIVAL:
                                    RolePicture = global::AvalonClient.Properties.Resources.Galahad;
                                    break;
                                case PlayingCards.SERVANT_OF_ARTHUR: {
                                        List<Bitmap> servants = new List<Bitmap>();
                                        servants.Add(global::AvalonClient.Properties.Resources.Lancelot);
                                        servants.Add(global::AvalonClient.Properties.Resources.Bedevere);
                                        servants.Add(global::AvalonClient.Properties.Resources.Patsy);
                                        servants.Add(global::AvalonClient.Properties.Resources.King_Arthur);
                                        int random = new Random().Next(0, servants.Count);
                                        RolePicture = servants[random];
                                    }
                                    break;
                                case PlayingCards.MINION_OF_MORDRED: {
                                        List<Bitmap> minions = new List<Bitmap>();
                                        minions.Add(global::AvalonClient.Properties.Resources.Nee);
                                        minions.Add(global::AvalonClient.Properties.Resources.Rabbit);
                                        int random = new Random().Next(0, minions.Count);
                                        RolePicture = minions[random];
                                    }
                                    break;
                                default:
                                    break;
                            }
                            cardValue.Text = Player.Card.ToString().Replace("_", " ");
                        });
                    }
                    break;
                case ServerRequest.CHOOSE_TEAM: {
                        PickTeam pickTeam = new PickTeam(MaxPlayersInTeam, PlayersPlaying);
                        pickTeam.TopLevel = false;
                        pickTeam.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        pickTeam.Dock = DockStyle.Fill;

                        this.Invoke((MethodInvoker)delegate {
                            infoPanel.Controls.Add(pickTeam);                           
                            pickTeam.Show();
                        });

                        while (pickTeam.DialogResult == System.Windows.Forms.DialogResult.None) {
                            Thread.Sleep(1000);
                        }

                        string team = "TEAM ";
                        foreach (String name in pickTeam.PlayersGoingOnMission) {
                            team += name + ";";
                        }
                        this.Invoke((MethodInvoker)delegate {
                            pickTeam.Close();
                            infoPanel.Controls.Remove(pickTeam);
                        });

                        TcpClient.SendMessage(team + "\n");
                    }
                    break;
                case ServerRequest.MISSION_VOTE_FAILS:
                    DisplayOutcome(!(FailedVotesInRound >= NeededFailVotes));
                    break;
                case ServerRequest.EVIL_WIN:
                    break;
                case ServerRequest.FIND_MERLIN:
                    break;
                case ServerRequest.GOOD_WIN:
                    break;
                case ServerRequest.KILL_MERLIN: {
                        List<string> names = new List<string>();
                        foreach (Players player in PlayersPlaying) {
                            if (player.Name != Player.Name && (player.Card != PlayingCards.MINION_OF_MORDRED && player.Card != PlayingCards.ASSASSIN &&
                                player.Card != PlayingCards.MORDRED && player.Card != PlayingCards.MORGANA && player.Card != PlayingCards.OBERON)) {
                                names.Add(player.Name);
                            }
                        }
                        PickMerlin pickMerlin = new PickMerlin(names);
                        pickMerlin.TopLevel = false;
                        pickMerlin.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        pickMerlin.Dock = DockStyle.Fill;

                        this.Invoke((MethodInvoker)delegate {
                            infoPanel.Controls.Add(pickMerlin);
                            pickMerlin.Show();
                        });

                        while (pickMerlin.DialogResult == System.Windows.Forms.DialogResult.None) {
                            Thread.Sleep(1000);
                        }

                        var index = ((ListBox)pickMerlin.Controls["playerListValue"]).SelectedIndex;
                        this.Invoke((MethodInvoker)delegate {
                            pickMerlin.Close();
                            infoPanel.Controls.Remove(pickMerlin);
                        });

                        TcpClient.SendMessage(names[index] + "\n");
                    }
                    break;
                case ServerRequest.LADY_OF_THE_LAKE:
                    break;
                case ServerRequest.MERLIN_KILLED:
                    MerlinOutcome merlinOutcome = new MerlinOutcome(MerlinKilled);
                    merlinOutcome.Show();
                    break;
                case ServerRequest.TEAM_VOTE: {
                        while (PlayersOnTeam == null || PlayersOnTeam.Count == 0) {
                            Thread.Sleep(1000);
                        }
                        bool result = false;
                        TeamVote teamVote = new TeamVote(PlayersOnTeam);
                        teamVote.TopLevel = false;
                        teamVote.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        teamVote.Dock = DockStyle.Fill;

                        this.Invoke((MethodInvoker)delegate {
                            infoPanel.Controls.Add(teamVote);
                            teamVote.Show();
                        });

                        while (teamVote.DialogResult == System.Windows.Forms.DialogResult.None) {
                            Thread.Sleep(1000);
                            if (teamVote.DialogResult == System.Windows.Forms.DialogResult.Yes) {
                                result = true;
                            }
                        }

                        this.Invoke((MethodInvoker)delegate {
                            teamVote.Close();
                            infoPanel.Controls.Remove(teamVote);
                        });

                        TcpClient.SendMessage(result.ToString() + "\n");
                    }
                    break;
                case ServerRequest.REQUEST_NAME:
                    Player.Name = nameValue.Text;
                    TcpClient.SendMessage(nameValue.Text);
                    break;
                case ServerRequest.RESET_MATCH:
                    SetTeamSelectionRound(1);
                    MoveVotePouch(true);
                    SetRound();
                    ClearPlayerCards();
                    break;
                case ServerRequest.PLAYERS_IN_GAME:
                    UpdatePlayersPanel();
                    break;
                case ServerRequest.RESET_TEAM_SELECTION_ROUND:
                    SetTeamSelectionRound(1);
                    MoveVotePouch(true);
                    break;
                case ServerRequest.REVEAL_PLAYERS:
                    break;
                case ServerRequest.TEAM_APPROVED:
                    DisplayTeamVote(true);
                    MoveVotePouch(true);
                    break;
                case ServerRequest.TEAM_REJECTED:
                    DisplayTeamVote(false);
                    MoveVotePouch();
                    break;
                case ServerRequest.UPDATE_SCORES:
                    break;
                case ServerRequest.VOTE_MISSION:
                    VoteForMission();
                    break;
                default:
                    break;
            }
        }

        private void MoveVotePouch(bool reset = false) {
            Bitmap pouch = global::AvalonClient.Properties.Resources.Pouch;
            if (!reset) {
                switch (CurrentTeamSelectionRound) {
                    case 1:
                        vote2.Image = pouch;
                        vote1.Image = global::AvalonClient.Properties.Resources.Vote1;
                        break;
                    case 2:
                        vote3.Image = pouch;
                        vote2.Image = global::AvalonClient.Properties.Resources.Vote2;
                        break;
                    case 3:
                        vote4.Image = pouch;
                        vote3.Image = global::AvalonClient.Properties.Resources.Vote3;
                        break;
                    case 4:
                        vote5.Image = pouch;
                        vote4.Image = global::AvalonClient.Properties.Resources.Vote4;
                        break;
                    default:
                        break;
                }
                CurrentTeamSelectionRound++;
            }
            else {
                vote1.Image = pouch;
                vote2.Image = global::AvalonClient.Properties.Resources.Vote2;
                vote3.Image = global::AvalonClient.Properties.Resources.Vote3;
                vote4.Image = global::AvalonClient.Properties.Resources.Vote4;
                vote5.Image = global::AvalonClient.Properties.Resources.Vote5;
                CurrentTeamSelectionRound = 1;
            }
        }

        private void VoteForMission() {
            bool result = false;
            MissionVote vote = new MissionVote(Player.Card);
            vote.TopLevel = false;
            vote.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vote.Dock = DockStyle.Fill;

            this.Invoke((MethodInvoker)delegate {
                infoPanel.Controls.Add(vote);
                vote.Show();
            });

            while (vote.DialogResult == System.Windows.Forms.DialogResult.None) {
                Thread.Sleep(1000);
            };

            if (vote.DialogResult == System.Windows.Forms.DialogResult.Yes) {
                result = true;
            }

            this.Invoke((MethodInvoker)delegate {
                vote.Close();
                infoPanel.Controls.Remove(vote);
            });

            TcpClient.SendMessage(result.ToString() + "\n");
           
        }

        private void DisplayTeamVote(bool result) {
            List<string> approved = new List<string>();
            List<string> rejected = new List<string>();
            foreach (Players player in PlayersPlaying) {
                if (player.TeamVote) {
                    approved.Add(player.Name);
                }
                else {
                    rejected.Add(player.Name);
                }
            }
            TeamOutcome outcome = new TeamOutcome(result, approved, rejected);
            outcome.TopLevel = false;
            outcome.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            outcome.Dock = DockStyle.Fill;

            this.Invoke((MethodInvoker)delegate {
                infoPanel.Controls.Add(outcome);
                outcome.Show();
            });

            while (outcome.DialogResult == System.Windows.Forms.DialogResult.None) {
                Thread.Sleep(1000);
            }

            this.Invoke((MethodInvoker) delegate {
                outcome.Close();
                infoPanel.Controls.Remove(outcome);
            });
        }

        private void DisplayOutcome(bool result) {
            ResultForm resultForm = new ResultForm(result, FailedVotesInRound);
            resultForm.TopLevel = false;
            resultForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            resultForm.Dock = DockStyle.Fill;

            this.Invoke((MethodInvoker)delegate {
                infoPanel.Controls.Add(resultForm);
                resultForm.Show();
            });

            while (resultForm.DialogResult == System.Windows.Forms.DialogResult.None) {
                Thread.Sleep(1000);
            }

            this.Invoke((MethodInvoker)delegate {
                resultForm.Close();
                infoPanel.Controls.Remove(resultForm);
            });

            FailedVotesInRound = 0;
            if (result) {
                CurrentRoundSuccess();
            }
            else {
                CurrentRoundFailed();
            }
            SetRound(1);
        }

        private void UpdatePlayersPanel() {
            this.Invoke((MethodInvoker)delegate {
                playersPlayingValue.Items.Clear();
                foreach (Players player in PlayersPlaying) {
                    if (player.Name != Player.Name) {
                        playersPlayingValue.Items.Add(player.Name);
                    }
                }
            });
        }

        private void CurrentRoundFailed() {
            if (CurrentRound == 1) {
                mission1.Image = global::AvalonClient.Properties.Resources.Fail_Chalicel;
            }
            else if (CurrentRound == 2) {
                mission2.Image = global::AvalonClient.Properties.Resources.Fail_Chalicel;
            }
            else if (CurrentRound == 3) {
                mission3.Image = global::AvalonClient.Properties.Resources.Fail_Chalicel;
            }
            else if (CurrentRound == 4) {
                mission4.Image = global::AvalonClient.Properties.Resources.Fail_Chalicel;
            }
            else if (CurrentRound == 5) {
                mission5.Image = global::AvalonClient.Properties.Resources.Fail_Chalicel;
            }
        }

        private void CurrentRoundSuccess() {
            if (CurrentRound == 1) {
                mission1.Image = global::AvalonClient.Properties.Resources.Success_Chalice;
            }
            else if (CurrentRound == 2) {
                mission2.Image = global::AvalonClient.Properties.Resources.Success_Chalice;
            }
            else if (CurrentRound == 3) {
                mission3.Image = global::AvalonClient.Properties.Resources.Success_Chalice;
            }
            else if (CurrentRound == 4) {
                mission4.Image = global::AvalonClient.Properties.Resources.Success_Chalice;
            }
            else if (CurrentRound == 5) {
                mission5.Image = global::AvalonClient.Properties.Resources.Success_Chalice;
            }
        }

        private void ClearPlayerCards() {
            List<Bitmap> background = new List<Bitmap>();
            background.Add(global::AvalonClient.Properties.Resources.BackDrop);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop2);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop3);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop4);
            background.Add(global::AvalonClient.Properties.Resources.BackDrop5);
            roundsPanel.BackgroundImage = background[new Random().Next(0, background.Count)];
        }

        private void SetRound(int round = 0) {
            if (round == 0) { //reset
                mission1.Image = global::AvalonClient.Properties.Resources.Round1;
                mission2.Image = global::AvalonClient.Properties.Resources.Round2;
                mission3.Image = global::AvalonClient.Properties.Resources.Round3;
                mission4.Image = global::AvalonClient.Properties.Resources.Round4;
                mission5.Image = global::AvalonClient.Properties.Resources.Round5;
                CurrentRound = 1;
            }
            else {
                CurrentRound++;
            }
        }

        private void SetTeamSelectionRound(int round = 0) {
            if (round == 0) {
                if (CurrentTeamSelectionRound == 1) {
                    
                    CurrentTeamSelectionRound++;
                }
                if (CurrentTeamSelectionRound == 2) {
                    
                    CurrentTeamSelectionRound++;
                }
                if (CurrentTeamSelectionRound == 3) {
                    
                    CurrentTeamSelectionRound++;
                }
                if (CurrentTeamSelectionRound == 4) {
                    
                    CurrentTeamSelectionRound++;
                }
            }
            else { //reset
                CurrentTeamSelectionRound = 1;
            }
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e) {
            try {
                stepLabel.Text = e.DataAsString.Substring(0, e.DataAsString.IndexOf("\n"));
                ParseMessageToInt(e.DataAsString.Replace("\0", ""));
            }
            catch (Exception){}
        }

        private void ParseMessageToInt(string message) {
            int result = 0;
            string[] msg = message.Split('\n');

            foreach (string msgString in msg) {
                if (!string.IsNullOrEmpty(msgString)) {
                    try {
                        result = (int)((ServerRequest)Enum.Parse(typeof(ServerRequest), msgString));
                    }
                    catch (Exception ex) { //we have some extra information attached with the message
                        try {
                            result = ParseExtraInformation(msgString);
                        }
                        catch (Exception innerEx) {
                            innerEx.ToString();
                        }
                    }

                    PerformServerRequest((ServerRequest)result);
                }
            }
        }

        private int ParseExtraInformation(string message) {
            int result = 0;

            string[] extraInfo = message.Split(';');
            if (message.StartsWith("PLAYERS_IN_GAME")) {
                lock (LockMe) {
                    PlayersPlaying.Clear();
                    foreach (string str in extraInfo) {
                        if (!string.IsNullOrEmpty(str)) {
                            string cleaned = str.Replace("PLAYERS_IN_GAME", "").Replace(";", "").Trim();
                            Players player = new Players();
                            player.Name = cleaned;
                            PlayersPlaying.Add(player);
                        }
                    }
                }

                result = (int)ServerRequest.PLAYERS_IN_GAME;
            }
            else if (message.StartsWith("TEAM_VOTE_RESULTS")) {
                lock (LockMe) {
                    PlayersOnTeam = new List<string>();
                    foreach (string str in extraInfo) {
                        if (!string.IsNullOrEmpty(str)) {
                            string cleaned = str.Replace("TEAM_VOTE_RESULTS", "").Replace(";", "").Trim();
                            foreach (Players player in PlayersPlaying) {
                                if (player.Name == cleaned.Replace(" True", "").Replace(" False", "")) {
                                    player.TeamVote = bool.Parse(cleaned.Replace(player.Name + " ", ""));
                                }
                            }
                        }
                    }
                }
                result = (int)ServerRequest.NONE;
            }
            else if (message.StartsWith("TEAM_VOTE")) {
                lock (LockMe) {
                   PlayersOnTeam = new List<string>();
                    foreach (string str in extraInfo) {
                        if (!string.IsNullOrEmpty(str)) {
                            string cleaned = str.Replace("TEAM_VOTE", "").Trim();
                            PlayersOnTeam.Add(cleaned);
                        }
                    }
                }
                result = (int)ServerRequest.TEAM_VOTE;
            }
            
            else if (message.StartsWith("KING")) {
                lock (LockMe) {
                    string msg = extraInfo[0].Replace("KING", "").Trim();
                    if (msg == Player.Name) {
                        Player.IsKing = true;
                    }
                    else {
                        Player.IsKing = false;
                    }
                }
                result = (int)ServerRequest.KING;
            }
            else if (message.StartsWith("LADY_OF_THE_LAKE")) {
                lock (LockMe) {
                    string msg = extraInfo[0].Replace("LADY_OF_THE_LAKE", "").Trim();
                    if (msg == Player.Name) {
                        Player.IsLadyLake = true;
                    }
                    else {
                        Player.IsLadyLake = false;
                    }
                }
                result = (int)ServerRequest.LADY_OF_THE_LAKE;
            }
            else if (message.StartsWith("ROLES")) {
                lock (LockMe) {
                    foreach (string str in extraInfo) {
                        if (!string.IsNullOrEmpty(str)) {
                            string cleaned = str.Replace("ROLES ", "").Replace(";", "").Trim();
                            string[] role = cleaned.Split(' ');
                            PlayersPlaying.Where(p => p.Name == role[0]).Single().Card = (PlayingCards)Enum.Parse(typeof(PlayingCards), role[1]);
                        }
                    }
                }
                result = (int)ServerRequest.ROLES;
            }
            else if (message.StartsWith("CHOOSE_TEAM")) {
                lock (LockMe) {
                    string msg = extraInfo[0].Replace("CHOOSE_TEAM", "").Trim();
                    MaxPlayersInTeam = int.Parse(msg);
                }
                result = (int)ServerRequest.CHOOSE_TEAM;
            }
            else if (message.StartsWith("MISSION_VOTE_FAILS")) {
                lock (LockMe) {
                    string msg = extraInfo[0].Replace("MISSION_VOTE_FAILS", "").Trim();
                    FailedVotesInRound = int.Parse(msg);
                    NeededFailVotes = int.Parse(extraInfo[1]);
                }
                result = (int)ServerRequest.MISSION_VOTE_FAILS;
            }
            else if (message.StartsWith("MERLIN_KILLED")) {
                lock (LockMe) {
                    string msg = extraInfo[0].Replace("MERLIN_KILLED", "").Trim();
                    MerlinKilled = bool.Parse(msg);
                }
                result = (int)ServerRequest.MERLIN_KILLED;
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e) {
            TcpClient.Dispose();
            statusValue.Text = "Disconnected";
            statusValue.ForeColor = System.Drawing.Color.Red;
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            Player.Name = nameValue.Text;
        }

        private void rolePicture_MouseHover(object sender, EventArgs e) {
            rolePicture.Image = RolePicture;
            cardValue.Visible = true;
        }

        private void rolePicture_MouseLeave(object sender, EventArgs e) {
            cardValue.Visible = false;
            rolePicture.Image = global::AvalonClient.Properties.Resources.card_back;
            foreach (int index in playersPlayingValue.SelectedIndices) {
                playersPlayingValue.SetSelected(index, false);
            }
        }

        private void rolePicture_Click(object sender, EventArgs e) {
            int index = 0;

            if (Player.Card == PlayingCards.MERLIN) {
                foreach (Players player in PlayersPlaying) {
                    if (player.Card == PlayingCards.MINION_OF_MORDRED ||
                        player.Card == PlayingCards.MORGANA ||
                        player.Card == PlayingCards.ASSASSIN ||
                        player.Card == PlayingCards.OBERON) {
                        playersPlayingValue.SetSelected(index, true);
                    }
                    index++;
                }
            }
            else if (Player.Card == PlayingCards.PERCIVAL) {
                foreach (Players player in PlayersPlaying) {
                    if (player.Card == PlayingCards.MORGANA ||
                        player.Card == PlayingCards.MERLIN) {
                        playersPlayingValue.SetSelected(index, true);
                    }
                    index++;
                }
            }
            else if (Player.Card == PlayingCards.OBERON) {
                foreach (Players player in PlayersPlaying) {
                    if (player.Card == PlayingCards.MINION_OF_MORDRED ||
                        player.Card == PlayingCards.MORGANA ||
                        player.Card == PlayingCards.ASSASSIN) {
                        playersPlayingValue.SetSelected(index, true);
                    }
                    index++;
                }
            }
            else if (Player.Card == PlayingCards.MINION_OF_MORDRED ||
                Player.Card == PlayingCards.MORGANA ||
                Player.Card == PlayingCards.MORDRED) {
                    foreach (Players player in PlayersPlaying) {
                        if (player.Name != Player.Name){
                            if (player.Card == PlayingCards.MINION_OF_MORDRED ||
                                player.Card == PlayingCards.MORGANA ||
                                player.Card == PlayingCards.ASSASSIN) {
                                playersPlayingValue.SetSelected(index, true);
                            }
                            index++;
                        }
                        
                    }
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (TcpClient != null) {
                TcpClient.Dispose();
            }
        } 
    }

    public enum ServerRequest {
        NONE, REQUEST_NAME, MISSION_VOTE_FAILS, GOOD_WIN, EVIL_WIN, MERLIN_KILLED, FIND_MERLIN, KILL_MERLIN,
        RESET_TEAM_SELECTION_ROUND, VOTE_MISSION, UPDATE_SCORES, REVEAL_PLAYERS, TEAM_REJECTED,
        TEAM_APPROVED, CHOOSE_TEAM, TEAM_VOTE, LADY_OF_THE_LAKE, TEAM_VOTE_RESULTS, ROLES,
        KING, RESET_MATCH, MERLIN, PERCIVAL, SERVANT_OF_ARTHUR, MORDRED, MORGANA,
        OBERON, ASSASSIN, MINION_OF_MORDRED, PLAYERS_IN_GAME
    }
}
