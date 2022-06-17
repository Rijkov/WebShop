namespace WebShop.BLL.Interfaces
{
    public interface IEmailSender
    {
        string SendMessage(string email, string fName, string lName, string recepient, string atachment = null);
    }
}
