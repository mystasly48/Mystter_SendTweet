namespace Mystter_SendTweet.Entities {
  public class Hashtag {
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public string NameWithMark => "#" + Name;

    public Hashtag() { }

    public Hashtag(string name, bool enabled) {
      this.Name = name;
      this.Enabled = enabled;
    }

    public override string ToString() {
      return this.Name;
    }

    public override bool Equals(object obj) {
      if (obj is Hashtag hashtag) {
        return this.Name == hashtag.Name;
      }
      return false;
    }

    public override int GetHashCode() {
      return this.Name.GetHashCode();
    }
  }
}
