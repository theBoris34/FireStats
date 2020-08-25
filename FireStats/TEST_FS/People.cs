namespace TEST_FS
{
    public class People
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public virtual Car Car { get; set; }

        public virtual Home Home { get; set; }


    }
}