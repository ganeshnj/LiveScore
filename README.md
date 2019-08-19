# LiveScore
A sample Xamarin app showing live score capability with help of SignalR.

## LiveScore.Admin
ASP.net Core 2.2 project used to manage teams and matches.

To Setup SQL Server on a mac/linux follow: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017

### Models
Team
Id, Name

Match
Id, Team1, Team2, ScoreTeam1, ScoreTeam2, Status

MatchStatus
Upcoming, Live, Ended

### MatchesController - API
API controller used to return list of matches and a single match

### MatchesController - MVC
MVC controller of match CURD operations.

### TeamController - MVC
MVC controller of team CURD operations.

### MatchHub
SignalR hub which is used to join and remove clients when detail page of a match is opened. On editing the match, the same hub is used to send the score information to all the eligible clients.

## LiveScore.Xam (.net standard 2.0)
A Xamarin app used to show the matches. The detail page of a match shows the live score and updates as soon as score is updated in the backend.

When detail page of a match is opened, client joins the group of a clients who are entitled to recieve score for it.