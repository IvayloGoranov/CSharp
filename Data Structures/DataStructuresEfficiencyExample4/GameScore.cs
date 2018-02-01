using System;

 public class GameScore : IComparable<GameScore>
{
     public GameScore(User user, int score)
     {
         this.User = user;
         this.Score = score;
     }
     
    public User User { get; private set; }

    public int Score { get; private set; }

    public int CompareTo(GameScore other)
    {
        if (other == null)
        {
            return -1;
        }

        int result = this.Score.CompareTo(other.Score);
        if (result > 0)
        {
            return -1; //The one with biggest score comes first.
        }
        else if (result < 0)
        {
            return 1;
        }
        else //If both have same score - standard comparison by username.
        {
            result = this.User.UserName.CompareTo(other.User.UserName);
        }

        return result;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.User.UserName, this.Score);
    }
}
