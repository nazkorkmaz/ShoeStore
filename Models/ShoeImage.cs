namespace ShoeStore.Models
{
    public class ShoeImage
    {
        public int  Id { get; set; }
        public int ShoeId { get; set; }

        public string FileName { get; set; }

        public bool IsDefaultImage { get; set; }

        public virtual Shoe Shoe { get; set; }
    }
}
