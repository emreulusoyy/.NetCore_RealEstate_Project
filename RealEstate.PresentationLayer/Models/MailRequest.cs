namespace RealEstate.PresentationLayer.Models
{
    public class MailRequest
    {
        public int Name { get; set; }
        public string SenderMail { get; set; }
        public string ReciverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
