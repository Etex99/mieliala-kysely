using System.Collections.Generic;

namespace Prototype
{
	public class Survey
	{
		public string introMessage { get; set; } = "default";
		public List<Emoji> emojis { get; set; }
		public string RoomCode { get; set; } = "default";
		
		//default survey consists of first intro entry, 7 emojis with various impact each with 3 first entries of activities.
		public Survey() {
			introMessage = Const.intros[0];
			emojis = new List<Emoji>();

			List<string> activities;

			Const.activities.TryGetValue(0, out activities);
			activities = activities.GetRange(0, 2);
			emojis.Add(new Emoji(0, "Iloinen", "positive", activities, "emoji0.png"));

			Const.activities.TryGetValue(1, out activities);
			activities = activities.GetRange(0, 2);
			emojis.Add(new Emoji(1, "H�mm�stynyt", "negative", activities, "emoji1.png"));

			Const.activities.TryGetValue(2, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(2, "Neutraali", "neutral", activities, "emoji2.png"));

			Const.activities.TryGetValue(3, out activities);
			activities = activities.GetRange(0, 2);
			emojis.Add(new Emoji(3, "Vihainen", "negative", activities, "emoji3.png"));

			Const.activities.TryGetValue(4, out activities);
			activities = activities.GetRange(0, 2);
			emojis.Add(new Emoji(4, "V�synyt", "neutral", activities, "emoji4.png"));

			Const.activities.TryGetValue(5, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(5, "Miettiv�", "neutral", activities, "emoji5.png"));

			Const.activities.TryGetValue(6, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(6, "Itkunauru", "positive", activities, "emoji6.png"));

			RoomCode = "1234";
		}

		//toString method for getting the info of the survey in a string for data purposes
		public override string ToString() {
			string value = "";

			value += $"Intro: {introMessage}\n";

			foreach (var item in emojis)
			{
				value += item.ToString();
				value += "\n";
			}

			value += $"RoomCode: {RoomCode}";

			return value;
		}
	}
}
