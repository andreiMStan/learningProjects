namespace NeT_6__EF_Core___SQLite_with_Code_First_Migrations
{
	public class RpgCharacter
	{


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string RpgClass { get; set; } = string.Empty;

        public int HitPoints { get; set; } = 100;
    }
}
