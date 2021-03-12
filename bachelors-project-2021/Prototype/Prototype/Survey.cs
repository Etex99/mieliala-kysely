using System.Collections.Generic;

namespace Prototype
{
	public class Survey
	{
		public string introMessage = "default";
		public List<Emoji> emojis;
		public string RoomCode = "default";
		
		//default survey consists of first intro entry, 7 emojis with various impact each with 3 first entries of activities.
		public Survey() {
			introMessage = Const.intros[0];
			emojis = new List<Emoji>();

			List<string> activities;

			Const.activities.TryGetValue(0, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(0, "Mood 0", 0, activities, "emoji0.txt"));

			Const.activities.TryGetValue(1, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(1, "Mood 1", 0, activities, "emoji1.txt"));

			Const.activities.TryGetValue(2, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(2, "Mood 2", 0, activities, "emoji2.txt"));

			Const.activities.TryGetValue(3, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(3, "Mood 3", 0, activities, "emoji3.txt"));

			Const.activities.TryGetValue(4, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(4, "Mood 4", 0, activities, "emoji4.txt"));

			Const.activities.TryGetValue(5, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(5, "Mood 5", 0, activities, "emoji5.txt"));

			Const.activities.TryGetValue(6, out activities);
			activities = activities.GetRange(0, 3);
			emojis.Add(new Emoji(6, "Mood 6", 0, activities, "emoji6.txt"));

			RoomCode = null;
		}

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
